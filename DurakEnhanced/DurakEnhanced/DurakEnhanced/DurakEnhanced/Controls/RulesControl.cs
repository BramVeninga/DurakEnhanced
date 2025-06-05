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

namespace DurakEnhanced.Controls
{
    public partial class RulesControl : UserControl
    {
        private MainForm mainForm;
        public RulesControl(MainForm mainForm = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Hide the GoBackButton if not in MainForm context
            GoBackButton.Visible = (mainForm != null);
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
