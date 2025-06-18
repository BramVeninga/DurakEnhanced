using DurakEnhanced;
using DurakEnhanced.Forms;
using DurakEnhanced.gameLogic;
using DurakEnhanced.gameLogic.ActionCards;
using DurakEnhanced.gameLogic.ActionCards.Tier1;
using DurakEnhanced.gameLogic.ActionCards.Troll;
using DurakEnhanced.gameLogic.ActionCards.Visual;
using DurakEnhanced.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private IDiceRoller diceRoller = new DiceRoller();
        private DiceRollerControl diceRollerControl;
        private FlowLayoutPanel actionCardPanel;
        private List<ActionCard> actionCards = new List<ActionCard>();


        public PlaygroundControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Load += PlaygroundControl_Load;
            var cardButtons = new List<Button> { Card1, Card2, Card3, Card4, Card5, Card6 };
            var trollCard = new TrollCard1(this);
            actionCards.Add(trollCard);
            actionCards.Add(new TrollCard2(cardButtons));
            actionCards.Add(new TrollCard3(this, cardButtons));

            var opponentCardButtons = new List<Button> { Card1, Card2, Card3, Card4, Card5, Card6 };
            

            var opponentCardBoxes = new List<PictureBox>
                {
                    pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7
                };

            var opponentCards = new List<Image>
                {
                    Properties.Resources.Hearts_Queen_white, // example cards
                    Properties.Resources.Hearts_5_white,
                    Properties.Resources.Pikes_Jack_white,
                    Properties.Resources.Hearts_5_white,
                    Properties.Resources.Clovers_2_white,
                    Properties.Resources.Clovers_Jack_white
                };
            foreach (var box in opponentCardBoxes)
            {
                box.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            var backImage = Properties.Resources.backofcard;
            var slot2Box = pictureBox3; // Assuming slot 2 is pictureBox3
            var revealedCard = Properties.Resources.Hearts_5_white;

            actionCards.Add(new Tier1Card1(slot2Box, revealedCard, backImage));
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {
            // Initialize the DiceRollerControl
            diceRollerControl = new DiceRollerControl
            {
                Size = new Size(600, 400),
                Visible = false
            };
            this.Controls.Add(diceRollerControl);
            this.Controls.SetChildIndex(diceRollerControl, 0);

            // Initialize Action Card Panel
            actionCardPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Location = new Point(this.ClientSize.Width - 310, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Red
            };
            this.Controls.Add(actionCardPanel);

            // Popup Menu Setup
            popupMenu = new IngamePopupControl { Visible = false };
            this.Controls.Add(popupMenu);
            this.Controls.SetChildIndex(popupMenu, 0);
            popupAnimator = new PopupAnimator(popupMenu);
            popupMenu.OnLeaveGameRequested = () =>
            {
                mainForm.LoadScreen(new MainMenuControl(mainForm));
            };

            // Give player a card
            
            DisplayActionCards();
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

        private void rollDiceButton_Click(object sender, EventArgs e)
        {
            // Center the DiceRollerControl within PlaygroundControl
            diceRollerControl.Left = (this.Width - diceRollerControl.Width) / 2;
            diceRollerControl.Top = (this.Height - diceRollerControl.Height) / 2;
            diceRollerControl.BringToFront();
            diceRollerControl.Visible = true;

            diceRollerControl.RollD20(result =>
            {
                rollResultLabel.Text = $"You rolled: {result}";
            });
        }

        private void DisplayActionCards()
        {
            actionCardPanel.Controls.Clear();

            // Create a shallow copy of the list to avoid modification issues
            var cardsToDisplay = actionCards.ToList();

            foreach (var card in cardsToDisplay)
            {
                var btn = new Button
                {
                    Text = card.Name,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                btn.Click += (s, e) =>
                {
                    Console.WriteLine($"[Click] Executing card: {card.Name}");
                    Console.WriteLine($"[Click] Cards before: {actionCards.Count}");
                    card.Execute();

                    bool removed = actionCards.Remove(card);
                    Console.WriteLine($"[Click] Removed: {removed}");
                    Console.WriteLine($"[Click] Cards after: {actionCards.Count}");

                    DisplayActionCards();
                };

                actionCardPanel.Controls.Add(btn);
            }
        }

        private void rollResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
