using DurakEnhanced.Forms;
using DurakEnhanced.gameLogic;
using DurakEnhanced.Networking;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class JoinableGamesListControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkManager;

        public JoinableGamesListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkManager = new NetworkManager();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optioneel: klik op de gamenaam
        }

        private void JoinableGamesList_Load(object sender, EventArgs e)
        {
            // Optioneel: automatisch lijst ophalen of andere initialisatie
        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinGameControl(mainForm));
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            string ip = ipTextBox.Text.Trim();
            if (!int.TryParse(portTextBox.Text.Trim(), out int port))
            {
                MessageBox.Show("Enter a valid port number.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                networkManager.ConnectToServer(ip, port);
                // Just load the PlaygroundControl directly
                mainForm.LoadScreen(new PlaygroundControl(mainForm, networkManager, isHost: false));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server:\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void portLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
