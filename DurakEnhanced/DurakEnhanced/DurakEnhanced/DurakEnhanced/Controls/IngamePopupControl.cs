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
    public partial class IngamePopupControl : UserControl
    {
        public Action OnLeaveGameRequested { get; set; }

        public IngamePopupControl()
        {
            InitializeComponent();

            // Set proper background
            Color.FromArgb(160, 0, 0, 0);

            // Fix rendering issues
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true
            );
            this.UpdateStyles();

            // Optional: force redraw if you're seeing flicker
            
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            new RulesForm().Show();
        }

        private void btnActionCards_Click(object sender, EventArgs e)
        {
            new ActionCardsForm().Show();
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            OnLeaveGameRequested?.Invoke();
        }

        private void IngamePopupControl_Load(object sender, EventArgs e)
        {
            // Optional: if you're dynamically modifying anything
        }
    }
}
