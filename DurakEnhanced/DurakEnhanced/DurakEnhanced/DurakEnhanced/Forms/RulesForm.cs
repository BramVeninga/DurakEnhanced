using DurakEnhanced.Controls;
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

namespace DurakEnhanced.Forms
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();
            var rulesControl = new RulesControl();
            rulesControl.Dock = DockStyle.Fill;
            this.Controls.Add(rulesControl);
        }
    }
}
