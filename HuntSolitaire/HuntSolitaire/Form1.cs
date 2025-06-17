using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntSolitaire
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        private PictureBox[] pileBoxes = new PictureBox[9];
        private PictureBox lastRemovedBox;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            StartNewGame();
        }

        private void SetupUI()
        {
            Text = "Пасьянс 'Охота'";
            Size = new Size(800, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Меню
            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem newGameItem = new ToolStripMenuItem("Новая игра");
            ToolStripMenuItem undoItem = new ToolStripMenuItem("Отменить ход");
            ToolStripMenuItem rulesItem = new ToolStripMenuItem("Правила");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход");

            newGameItem.Click += (s, e) => StartNewGame();
            undoItem.Click += (s, e) => UndoMove();
            rulesItem.Click += (s, e) => ShowRules();
            exitItem.Click += (s, e) => Close();

            menu.Items.AddRange(new ToolStripItem[] { newGameItem, undoItem, rulesItem, exitItem });
            Controls.Add(menu);

            // Создаем стопки карт
            for (int i = 0; i < 9; i++)
            {
                pileBoxes[i] = new PictureBox
                {
                    Size = new Size(71, 96),
                    Location = new Point(50 + (i % 3) * 80, 50 + (i / 3) * 110),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Green
                };
                pileBoxes[i].Click += PileBox_Click;
                pileBoxes[i].Tag = i;
                Controls.Add(pileBoxes[i]);
            }

            // Поле для удаленных карт
            lastRemovedBox = new PictureBox
            {
                Size = new Size(71, 96),
                Location = new Point(650, 50),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray
            };
            Controls.Add(lastRemovedBox);

            // Подпись для удаленных карт
            Label removedLabel = new Label
            {
                Text = "Удаленные карты:",
                Location = new Point(650, 30),
                AutoSize = true
            };
            Controls.Add(removedLabel);
        }

        private void StartNewGame()
        {
            game.InitializeDeck();
            UpdateUI();
        }

        private void UpdateUI()
        {
            for (int i = 0; i < 9; i++)
            {
                Card topCard = game.GetTopCard(i);
                pileBoxes[i].Image = topCard?.Image;
                pileBoxes[i].BorderStyle =
                    (game.SelectedCard != null && topCard == game.SelectedCard) ?
                    BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }

            lastRemovedBox.Image = game.LastRemovedCard?.Image;
        }

        private void PileBox_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            int pileIndex = (int)box.Tag;
            Card card = game.GetTopCard(pileIndex);

            if (card == null) return;

            if (game.SelectedCard == null)
            {
                game.SelectedCard = card;
            }
            else if (game.SelectedCard == card)
            {
                game.SelectedCard = null;
            }
            else
            {
                if (game.TryRemovePair(card))
                {
                    if (game.IsGameWon())
                    {
                        MessageBox.Show("Поздравляем! Вы выиграли!", "Победа",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            UpdateUI();
        }

        private void UndoMove()
        {
            game.UndoLastMove();
            UpdateUI();
        }

        private void ShowRules()
        {
            string rules = "Правила пасьянса 'Охота':\n\n" +
                          "1. Используется колода из 36 карт\n" +
                          "2. Карты раскладываются в 9 стопок по 4 карты\n" +
                          "3. Вы можете убирать пары карт одинакового достоинства\n" +
                          "4. Для этого кликните на первую карту, затем на вторую\n" +
                          "5. Цель игры - убрать все карты с поля";

            MessageBox.Show(rules, "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}