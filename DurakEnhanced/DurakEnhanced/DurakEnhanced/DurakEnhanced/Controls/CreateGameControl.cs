using DurakEnhanced.Forms;
using DurakEnhanced.Networking;
using System;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class CreateGameControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkManager;

        public CreateGameControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            networkManager = new NetworkManager();
            networkManager.MessageReceived += NetworkManager_MessageReceived;
        }

        private void GameLogo_Click(object sender, EventArgs e)
        {
            // Eventueel iets met logo klikken
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Eventueel validatie of naam ophalen
        }

        private void CreateGameControl_Load(object sender, EventArgs e)
        {
            // Niet nodig voor nu
        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void CreateGameButton_Click(object sender, EventArgs e)
        {
            string playerName = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            try
            {
                networkManager.StartServer(5000); // Start server op poort 5000
                var waitingScreen = new WaitingScreenControl(mainForm);
                waitingScreen.SetStatus("Server started. Waiting for connection...");
                mainForm.LoadScreen(waitingScreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start server: " + ex.Message);
            }
        }

        private void NetworkManager_MessageReceived(string message)
        {
            // Optioneel: log of toon ontvangen berichten
            MessageBox.Show("Message received: " + message);
        }
    }
}
