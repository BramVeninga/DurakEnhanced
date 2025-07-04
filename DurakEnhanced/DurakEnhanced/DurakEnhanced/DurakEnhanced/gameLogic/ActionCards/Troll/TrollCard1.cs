using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.gameLogic.ActionCards.Troll
{

        public class TrollCard1 : ActionCard
        {
            private readonly Control opponentView;

            public TrollCard1(Control opponentView) : base("Troll Face")
            {
                this.opponentView = opponentView;
            }

            public override void Execute()
            {
                // Optional message for testing
                Console.WriteLine("[TrollCard1] Activated");

                // Create semi-transparent black overlay
                var overlay = new Panel
                {
                    BackColor = Color.FromArgb(200, 0, 0, 0), // semi-transparent black
                    Dock = DockStyle.Fill
                };

                // Optionally add a label or image in the center
                var label = new Label
                {
                    Text = "😈 Trolled!",
                    ForeColor = Color.White,
                    Font = new Font("Arial", 32, FontStyle.Bold),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                // Center the label
                label.Location = new Point(
                    (opponentView.Width - label.Width) / 2,
                    (opponentView.Height - label.Height) / 2
                );

                overlay.Controls.Add(label);
                overlay.BringToFront();

                opponentView.Controls.Add(overlay);
                opponentView.Controls.SetChildIndex(overlay, 0);

                // Timer to remove overlay after 3 seconds
                var timer = new Timer { Interval = 3000 };
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    opponentView.Controls.Remove(overlay);
                    overlay.Dispose();
                    timer.Dispose();
                    Console.WriteLine("[TrollCard1] Overlay removed");
                };
                timer.Start();
            }
        }
    }
