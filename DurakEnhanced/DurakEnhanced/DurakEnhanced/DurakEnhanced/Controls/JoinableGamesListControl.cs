using DurakEnhanced.Forms;
using System;
using System.Windows.Forms;
using DurakEnhanced.Networking;

namespace DurakEnhanced.Controls
{
    public partial class JoinableGamesListControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkmanager;

        public JoinableGamesListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkmanager = new NetworkManager();
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

            // Hier zou normaal je connectielogica komen
            // Bijvoorbeeld: networkManager.ConnectToServer(ip, port);

            mainForm.LoadScreen(new PlaygroundControl(mainForm, networkmanager));
        }
    }
}
