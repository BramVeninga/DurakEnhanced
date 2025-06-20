using DurakEnhanced.GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.Helpers
{
    public static class CardUIHelper
    {
        public static Button CreatePlayerCardButton(Card card)
        {
            var btn = new Button
            {
                BackgroundImage = GetCardImage(card),
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(135, 199),
                FlatStyle = FlatStyle.Flat,
                Tag = card,
                Margin = new Padding(5),
                BackColor = Color.Transparent
            };
            btn.FlatAppearance.BorderSize = 0;

            btn.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.DoDragDrop(card, DragDropEffects.Move);
            };

            return btn;
        }


        public static PictureBox CreateOpponentCardBack()
        {
            return new PictureBox
            {
                Image = Properties.Resources.backofcard,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(135, 199),
                Margin = new Padding(0),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None
            };
        }

        public static Image GetCardImage(Card card)
        {
            string suit = GetSuitString(card.Suit);  // e.g., Spades
            string rank = MapRank(card.Rank);    // Convert to "9" instead of "Nine"

            string resourceName = $"{suit}_{rank}_white";
            var image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

            if (image == null)
                Console.WriteLine($"[WARN] Card image not found for resource: {resourceName}");

            return image;
        }

        private static string GetSuitString(Suit suit)
        {
            switch (suit)
            {
                case Suit.Clubs: return "Clovers";
                case Suit.Spades: return "Pikes";
                case Suit.Hearts: return "Hearts";
                case Suit.Diamonds: return "Tiles";
                default: return suit.ToString(); // fallback
            }
        }

        private static string MapRank(Rank rank)
        {
            switch (rank)
            {
                case Rank.Six: return "6";
                case Rank.Seven: return "7";
                case Rank.Eight: return "8";
                case Rank.Nine: return "9";
                case Rank.Ten: return "10";
                case Rank.Jack: return "Jack";
                case Rank.Queen: return "Queen";
                case Rank.King: return "King";
                case Rank.Ace: return "A";
                default: return rank.ToString();
            }
        }

        public static Button CreateBattlefieldCardButton(Card card)
        {
            return new Button
            {
                BackgroundImage = GetCardImage(card),
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(135, 199),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5),
                BackColor = Color.Transparent,
                Tag = card
            };
        }

        public static PictureBox CreateCardImageOnly(Card card)
        {
            return new PictureBox
            {
                Image = GetCardImage(card),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(135, 199),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None
            };
        }


    }

}
