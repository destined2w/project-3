using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace HuntSolitaire
{
    public class Card
    {
        public string Rank { get; }
        public string Suit { get; }
        public Image Image { get; }

        public Card(string rank, string suit, Image image)
        {
            Rank = rank;
            Suit = suit;
            Image = image;
        }

        public static Image LoadCardImage(string rank, string suit)
        {
            string imageName = $"{rank}_of_{suit}";
            try
            {
                return Image.FromFile($"Cards/{imageName}.png");
            }
            catch
            {
                // Если изображение не найдено, создаем placeholder
                return CreatePlaceholderImage(rank, suit);
            }
        }

        private static Image CreatePlaceholderImage(string rank, string suit)
        {
            Bitmap bmp = new Bitmap(71, 96);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", 10))
                {
                    g.DrawString($"{rank} of {suit}", font, Brushes.Black, new PointF(5, 40));
                }
            }
            return bmp;
        }
    }
}