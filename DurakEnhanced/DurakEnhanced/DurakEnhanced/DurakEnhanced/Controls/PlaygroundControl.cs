using DurakEnhanced.Forms;
using DurakEnhanced.Helpers;
using DurakEnhanced.Networking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class PlaygroundControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkManager;
        private Button selectedCard = null;
        private int cardLiftOffset = 20;
        private IngamePopupControl popupMenu;
        private PopupAnimator popupAnimator;

        public PlaygroundControl(MainForm mainForm, NetworkManager networkManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkManager = networkManager;

            // Koppel event handler voor inkomende berichten
            this.networkManager.MessageReceived += NetworkManager_MessageReceived;
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {
            popupMenu = new IngamePopupControl { Visible = false };
            this.Controls.Add(popupMenu);
            this.Controls.SetChildIndex(popupMenu, 0);
            popupAnimator = new PopupAnimator(popupMenu);
            popupMenu.OnLeaveGameRequested = () =>
            {
                networkManager?.StopServer(); // Sluit eventuele server netjes af
                mainForm.LoadScreen(new MainMenuControl(mainForm));
            };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            networkManager?.StopServer(); // Sluit netjes af bij exit
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void Card1_Click(object sender, EventArgs e) => HandleCardClick(Card1, "Card1");
        private void Card2_Click(object sender, EventArgs e) => HandleCardClick(Card2, "Card2");
        private void Card3_Click(object sender, EventArgs e) => HandleCardClick(Card3, "Card3");
        private void Card4_Click(object sender, EventArgs e) => HandleCardClick(Card4, "Card4");
        private void Card5_Click(object sender, EventArgs e) => HandleCardClick(Card5, "Card5");
        private void Card6_Click(object sender, EventArgs e) => HandleCardClick(Card6, "Card6");

        private void HandleCardClick(Button cardButton, string cardId)
        {
            CardSelectorHelper.HandleCardClick(ref selectedCard, cardButton, cardLiftOffset);

            // Stuur kaartselectie naar tegenstander
            try
            {
                networkManager?.SendMessage($"CardSelected|{cardId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij verzenden kaartselectie: " + ex.Message);
            }
        }

        private void NetworkManager_MessageReceived(string message)
        {
            // Verwerk binnenkomende berichten
            if (InvokeRequired)
            {
                Invoke(new Action(() => NetworkManager_MessageReceived(message)));
                return;
            }

            if (message.StartsWith("CardSelected|"))
            {
                string cardId = message.Substring("CardSelected|".Length);
                MessageBox.Show($"Tegenstander selecteerde: {cardId}");
                // Je kunt hier visueel markeren of de kaart op tafel leggen
            }
            else
            {
                MessageBox.Show("Bericht ontvangen: " + message);
            }
        }

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