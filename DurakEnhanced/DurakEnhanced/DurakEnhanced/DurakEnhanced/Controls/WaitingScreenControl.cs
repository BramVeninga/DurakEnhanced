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

        // Publieke methode om de status bij te werken
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
    }
}
