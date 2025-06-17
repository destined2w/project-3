using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntSolitaire
{
    public class Game
    {
        private List<Card>[] piles = new List<Card>[9];
        private Card selectedCard = null;
        private Stack<MoveHistory> undoStack = new Stack<MoveHistory>();

        public Card SelectedCard
        {
            get => selectedCard;
            set => selectedCard = value;
        }

        public void InitializeDeck()
        {
            undoStack.Clear();
            selectedCard = null;

            for (int i = 0; i < 9; i++)
            {
                piles[i] = new List<Card>();
            }

            var tempDeck = new List<Card>();
            string[] ranks = { "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Image cardImage = Card.LoadCardImage(rank, suit);
                    tempDeck.Add(new Card(rank, suit, cardImage));
                }
            }

            Random rnd = new Random();
            tempDeck = tempDeck.OrderBy(c => rnd.Next()).ToList();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tempDeck.Count > 0)
                    {
                        piles[i].Add(tempDeck[0]);
                        tempDeck.RemoveAt(0);
                    }
                }
            }
        }
        private Card lastRemovedCard = null;
        public Card LastRemovedCard => lastRemovedCard;
        public Card GetTopCard(int pileIndex)
        {
            if (piles[pileIndex].Count == 0) return null;
            return piles[pileIndex][piles[pileIndex].Count - 1];
        }

        public bool TryRemovePair(Card card)
        {
            if (selectedCard == null || card == null) return false;

            if (selectedCard.Rank != card.Rank) return false;

            int pileIndex1 = -1, pileIndex2 = -1;
            for (int i = 0; i < 9; i++)
            {
                if (GetTopCard(i) == selectedCard) pileIndex1 = i;
                if (GetTopCard(i) == card) pileIndex2 = i;
            }

            undoStack.Push(new MoveHistory
            {
                PileIndex1 = pileIndex1,
                PileIndex2 = pileIndex2,
                Card1 = selectedCard,
                Card2 = card
            });

            piles[pileIndex1].RemoveAt(piles[pileIndex1].Count - 1);
            piles[pileIndex2].RemoveAt(piles[pileIndex2].Count - 1);

            lastRemovedCard = card;

            selectedCard = null;
            return true;
        }

        public void UndoLastMove()
        {
            if (undoStack.Count == 0) return;

            MoveHistory move = undoStack.Pop();
            piles[move.PileIndex1].Add(move.Card1);
            piles[move.PileIndex2].Add(move.Card2);

            lastRemovedCard = null;

            selectedCard = null;
        }

        public bool IsGameWon()
        {
            return piles.All(pile => pile.Count == 0);
        }

        private class MoveHistory
        {
            public int PileIndex1 { get; set; }
            public int PileIndex2 { get; set; }
            public Card Card1 { get; set; }
            public Card Card2 { get; set; }
        }
    }
}