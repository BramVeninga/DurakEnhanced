using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakEnhanced.Forms;

namespace DurakEnhanced.Controls
{
    public partial class MainMenuControl : UserControl
    {

        private MainForm mainForm; // store the reference
        public MainMenuControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void MainMenuControl_Load(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinGameControl(mainForm)); 
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {

        }

        private void ActionCardsButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
