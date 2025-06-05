using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.Helpers
{
    public class PopupAnimator
    {
        private readonly Control popup;
        private readonly Timer timer = new Timer();
        private int targetY;
        private int speed;

        public PopupAnimator(Control popup, int speed = 20)
        {
            this.popup = popup;
            this.speed = speed;
            timer.Interval = 10;
            timer.Tick += Animate;
        }

        public void Start(int startY, int targetY)
        {
            popup.Top = startY;
            this.targetY = targetY;
            popup.Visible = true;
            timer.Start();
        }

        private void Animate(object sender, EventArgs e)
        {
            if (popup.Top < targetY)
                popup.Top += speed;
            else
            {
                popup.Top = targetY;
                timer.Stop();
            }
        }
    }
}

