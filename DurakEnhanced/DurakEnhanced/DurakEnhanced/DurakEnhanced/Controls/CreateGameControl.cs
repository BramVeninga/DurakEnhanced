using DurakEnhanced.Forms;
using DurakEnhanced.Networking;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            // Do nothing or add animation/logo action
        }

        private void GameNameTextbox_TextChanged(object sender, EventArgs e)
        {
            // Optional: live validation or UI feedback
        }

        private void CreateGameControl_Load(object sender, EventArgs e)
        {
            // Optional on-load logic
        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinGameControl(mainForm));
        }

        private void CreateGameButton_Click(object sender, EventArgs e)
        {
            string playerName = GameNameTextbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName) || playerName.Length < 3)
            {
                MessageBox.Show("Please enter a valid name (at least 3 characters).", "Invalid Game Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int port = 5000;
                networkManager.StartServer(port);

                string ip = GetLocalIPAddress();
                int usedPort = GetPortFromListener(networkManager.Server);

                var waitingScreen = new WaitingScreenControl(mainForm, networkManager);
                waitingScreen.SetConnectionInfo(ip, usedPort);

                mainForm.LoadScreen(waitingScreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start server: " + ex.Message);
            }
        }

        private void NetworkManager_MessageReceived(string message)
        {
            // Optional: log or act on received message
            MessageBox.Show("Message received: " + message);
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return ip?.ToString() ?? "127.0.0.1";
        }

        private int GetPortFromListener(TcpListener listener)
        {
            return ((IPEndPoint)listener.LocalEndpoint).Port;
        }
    }
}
