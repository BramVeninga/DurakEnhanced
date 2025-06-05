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
using DurakEnhanced;

namespace DurakEnhanced.Controls
{
    public partial class JoinableGamesListControl : UserControl
    {
        private MainForm mainForm;
        public JoinableGamesListControl(MainForm mainform)
        {
            InitializeComponent();
            this.mainForm = mainform;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void JoinableGamesList_Load(object sender, EventArgs e)
        {

        }

        private void GoBackButon_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new JoinGameControl(mainForm));
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadScreen(new PlaygroundControl(mainForm));
        }
    }
}
