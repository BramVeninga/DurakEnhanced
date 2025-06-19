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
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Stop de server
            networkManager?.StopServer();

            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void play_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new PlaygroundControl(mainForm));
        }

        public void SetConnectionInfo(string ip, int port)
        {
            string connectionText = $"IP: {ip}\nPort: {port}";
            if (InvokeRequired)
                Invoke(new Action(() => labelConnectionInfo.Text = connectionText));
            else
                labelConnectionInfo.Text = connectionText;
        }
    }
}
