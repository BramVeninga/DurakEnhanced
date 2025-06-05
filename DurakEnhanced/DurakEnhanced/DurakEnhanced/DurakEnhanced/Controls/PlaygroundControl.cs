using DurakEnhanced.Forms;
using DurakEnhanced.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class PlaygroundControl : UserControl
    {
        private MainForm mainForm;
        private Button selectedCard = null;
        private int cardLiftOffset = 20;
        private IngamePopupControl popupMenu;
        private PopupAnimator popupAnimator;

        public PlaygroundControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {
            popupMenu = new IngamePopupControl { Visible = false };
            this.Controls.Add(popupMenu);
            this.Controls.SetChildIndex(popupMenu, 0);
            popupAnimator = new PopupAnimator(popupMenu);
            popupMenu.OnLeaveGameRequested = () =>
            {
                mainForm.LoadScreen(new MainMenuControl(mainForm));
            };
        }

        private void ExitButton_Click(object sender, EventArgs e) =>
            mainForm.LoadScreen(new MainMenuControl(mainForm));


        private void Card1_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card1, cardLiftOffset);
        private void Card2_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card2, cardLiftOffset);
        private void Card3_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card3, cardLiftOffset);
        private void Card4_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card4, cardLiftOffset);
        private void Card5_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card5, cardLiftOffset);
        private void Card6_Click(object sender, EventArgs e) => CardSelectorHelper.HandleCardClick(ref selectedCard, Card6, cardLiftOffset);

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!popupMenu.Visible)
                {
                    var centerX = (this.Width - popupMenu.Width) / 2;
                    popupMenu.Left = centerX;
                    popupAnimator.Start(-popupMenu.Height, (this.Height - popupMenu.Height) / 2);
                }
                else
                {
                    popupMenu.Visible = false;
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
