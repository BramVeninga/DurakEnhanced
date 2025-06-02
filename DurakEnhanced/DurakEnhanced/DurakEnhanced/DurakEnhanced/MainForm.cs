using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakEnhanced.Controls;
using DurakEnhanced;

namespace DurakEnhanced.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadScreen(new MainMenuControl(this));
        }
        public void LoadScreen(UserControl screen)
        {
            Console.WriteLine("Loading screen: " + screen.GetType().Name);
            screen.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(screen);
            screen.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && panel1.Controls.Count > 0)
            {
                var currentControl = panel1.Controls[0];

                if (currentControl is JoinGameControl)
                {
                    LoadScreen(new MainMenuControl(this));
                    return true;
                } else if(currentControl is CreateGameControl) {
                    LoadScreen(new JoinGameControl(this));
                    return true;
                } else if (currentControl is JoinableGamesListControl) {
                    LoadScreen(new JoinGameControl(this));
                    return true;
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
