using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakEnhanced.Forms; // Ensure you have the correct namespace for your forms
using DurakEnhanced.Controls; // Ensure you have the correct namespace for your controls
using DurakEnhanced;


namespace DurakEnhanced.Controls
{
    public partial class JoinGameControl : UserControl
    {

        private MainForm mainForm; // store the reference to MainForm

        public JoinGameControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void JoinGameControl_Load(object sender, EventArgs e)
        {
            
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinableGamesListControl(mainForm));
        }

        private void CreateGameButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new CreateGameControl(mainForm));
        }
    }
}
