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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateGameControl_Load(object sender, EventArgs e)
        {

        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
                
        }

        private void CreateGameButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new WaitingScreenControl(mainForm));
        }
    }
}
