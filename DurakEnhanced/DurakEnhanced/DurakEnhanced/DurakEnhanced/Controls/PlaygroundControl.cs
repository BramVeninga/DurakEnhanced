using DurakEnhanced.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class PlaygroundControl : UserControl
    {
        private MainForm mainForm;
        private Button selectedCard = null;
        private int cardLiftOffset = 20; 


        public PlaygroundControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void Card1_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card1);
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card2);
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card3);
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card4);
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card5);
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            HandleCardClick(Card6);
        }
        private void HandleCardClick(Button clickedCard)
        {
            if (selectedCard != null && selectedCard != clickedCard)
            {
                // Move previous card down
                selectedCard.Location = new Point(selectedCard.Location.X, selectedCard.Location.Y + cardLiftOffset);
            }

            if (clickedCard != selectedCard)
            {
                // Move new card up
                clickedCard.Location = new Point(clickedCard.Location.X, clickedCard.Location.Y - cardLiftOffset);
                selectedCard = clickedCard;
            }
            else
            {
                // Deselect clicked card
                clickedCard.Location = new Point(clickedCard.Location.X, clickedCard.Location.Y + cardLiftOffset);
                selectedCard = null;
            }
        }

    }
}
