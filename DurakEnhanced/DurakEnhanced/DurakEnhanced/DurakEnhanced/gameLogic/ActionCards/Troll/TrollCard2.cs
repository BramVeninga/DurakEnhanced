using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.gameLogic.ActionCards.Troll
{
    public class TrollCard2 : ActionCard
    {
        private readonly List<Button> targetCardButtons;

        public TrollCard2(List<Button> cardButtons) : base("Troll Shuffle")
        {
            targetCardButtons = cardButtons;
        }

        public override void Execute()
        {
            Console.WriteLine("[TrollCard2] Activated!");

            if (targetCardButtons.Count < 2)
                return;

            // Store original positions
            var originalPositions = targetCardButtons.ToDictionary(btn => btn, btn => btn.Location);

            var rng = new Random();

            // Shuffle positions randomly
            var shuffledButtons = new List<Button>(targetCardButtons);
            shuffledButtons = shuffledButtons.OrderBy(_ => rng.Next()).ToList();

            for (int i = 0; i < shuffledButtons.Count; i++)
            {
                shuffledButtons[i].Location = originalPositions[targetCardButtons[i]];
            }

            // Restore after 3 seconds
            Timer restoreTimer = new Timer { Interval = 3000 };
            restoreTimer.Tick += (s, e) =>
            {
                restoreTimer.Stop();
                foreach (var kvp in originalPositions)
                {
                    kvp.Key.Location = kvp.Value;
                }
                Console.WriteLine("[TrollCard2] Card positions restored.");
            };
            restoreTimer.Start();
        }
    }
}
