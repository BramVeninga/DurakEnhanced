using DurakEnhanced.Forms;
using DurakEnhanced.Networking;
using DurakEnhanced.Utils;
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
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CreateGameControl_Load(object sender, EventArgs e)
        {
            
        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinGameControl(mainForm));
        }

        private void CreateGameButton_Click(object sender, EventArgs e)
        {
            string playerName = textBox1.Text.Trim();

            if (!InputValidator.IsGameNameValid(playerName))
            {
                MessageBox.Show("Please enter a valid name for the game.", "Invalid Game Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                networkManager.StartServer(5000); // Start server on port 5000
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
            // Optional: handle or log incoming messages
            MessageBox.Show("Message received: " + message);
        }
    }
}
