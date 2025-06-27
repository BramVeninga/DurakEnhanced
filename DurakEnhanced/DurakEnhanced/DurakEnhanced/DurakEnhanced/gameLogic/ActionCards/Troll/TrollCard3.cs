using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DurakEnhanced.gameLogic.ActionCards.Troll
{
    public class TrollCard3 : ActionCard
    {
        private readonly Control parentControl;
        private readonly List<Button> targetCardButtons;
        private readonly Image backImage;

        public TrollCard3(Control parentControl, List<Button> targetCardButtons) : base("Card Blur")
        {
            this.parentControl = parentControl;
            this.targetCardButtons = targetCardButtons;

            // Load from resources
            backImage = Properties.Resources.backofcard;
        }

        public override void Execute()
        {
            Console.WriteLine("[TrollCard3] Activated!");

            if (targetCardButtons.Count == 0)
            {
                Console.WriteLine("[TrollCard3] No target buttons.");
                return;
            }

            var rng = new Random();
            var shuffled = new List<Button>(targetCardButtons);
            int toBlur = Math.Min(3, shuffled.Count); // Blur up to 3
            shuffled = shuffled.OrderBy(_ => rng.Next()).ToList();

            var buttonsToBlur = shuffled.Take(toBlur).ToList();
            var originalImages = new Dictionary<Button, Image>();

            foreach (var btn in buttonsToBlur)
            {
                originalImages[btn] = btn.BackgroundImage;
                btn.BackgroundImage = backImage;
            }

            Timer restoreTimer = new Timer { Interval = 3000 };
            restoreTimer.Tick += (s, e) =>
            {
                restoreTimer.Stop();
                foreach (var pair in originalImages)
                {
                    pair.Key.BackgroundImage = pair.Value;
                }
                Console.WriteLine("[TrollCard3] Restored blurred card images.");
            };
            restoreTimer.Start();
        }
    }
}
