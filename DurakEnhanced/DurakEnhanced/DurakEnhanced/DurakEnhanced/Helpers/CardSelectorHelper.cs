using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurakEnhanced;
using System.Windows.Forms;

namespace DurakEnhanced.Helpers
{
    public static class CardSelectorHelper
    {
        public static void HandleCardClick(ref Button selectedCard, Button clickedCard, int liftOffset)
        {
            if (selectedCard != null && selectedCard != clickedCard)
                selectedCard.Location = new Point(selectedCard.Location.X, selectedCard.Location.Y + liftOffset);

            if (clickedCard != selectedCard)
            {
                clickedCard.Location = new Point(clickedCard.Location.X, clickedCard.Location.Y - liftOffset);
                selectedCard = clickedCard;
            }
            else
            {
                clickedCard.Location = new Point(clickedCard.Location.X, clickedCard.Location.Y + liftOffset);
                selectedCard = null;
            }
        }
    }
}

