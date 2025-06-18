using DurakEnhanced.Forms;
using System;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class WaitingScreenControl : UserControl
    {
        private MainForm mainForm;

        public WaitingScreenControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void play_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new PlaygroundControl(mainForm));
        }

        // Update status (e.g. waiting...)
        public void SetStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => label1.Text = message));
            }
            else
            {
                label1.Text = message;
            }
        }

        // Update connection info (IP and Port)
        public void SetConnectionInfo(string ip, int port)
        {
            string info = $"IP Address: {ip}\nPort: {port}";
            if (InvokeRequired)
            {
                Invoke(new Action(() => labelConnectionInfo.Text = info));
            }
            else
            {
                labelConnectionInfo.Text = info;
            }
        }
    }
}
