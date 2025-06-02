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
    }
}
