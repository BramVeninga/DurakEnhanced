using DurakEnhanced.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakEnhanced.Utils;

namespace DurakEnhanced.Controls
{
    public partial class CreateGameControl : UserControl
    {
        private MainForm mainForm; // store the reference to MainForm

        public CreateGameControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void GameLogo_Click(object sender, EventArgs e)
        {

        }

        private void GameNameTextbox_TextChanged(object sender, EventArgs e)
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
            if (!InputValidator.IsGameNameValid(GameNameTextbox.Text))
            {
                MessageBox.Show("Please enter a valid name for the game.", "Invalid Game Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mainForm.LoadScreen(new WaitingScreenControl(mainForm));
        }
    }
}
