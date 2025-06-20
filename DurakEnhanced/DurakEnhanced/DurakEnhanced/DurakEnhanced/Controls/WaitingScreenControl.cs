using DurakEnhanced.Forms;
using DurakEnhanced.Networking;
using System;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class WaitingScreenControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkManager;

        public WaitingScreenControl(MainForm mainForm, NetworkManager networkManager)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkManager = networkManager;
            this.networkManager.MessageReceived += NetworkManager_MessageReceived;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Stop de server
            networkManager?.StopServer();

            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        public void SetConnectionInfo(string ip, int port)
        {
            string connectionText = $"IP: {ip}\nPort: {port}";
            if (InvokeRequired)
                Invoke(new Action(() => labelConnectionInfo.Text = connectionText));

            else
                labelConnectionInfo.Text = connectionText;
        }

        private void NetworkManager_MessageReceived(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => NetworkManager_MessageReceived(message)));
                return;
            }

            if (message == "ClientConnected")
            {
                mainForm.LoadScreen(new PlaygroundControl(mainForm, networkManager, true));
                Console.WriteLine("Client connected! Switching to game.");

            }
        }
    }
}
