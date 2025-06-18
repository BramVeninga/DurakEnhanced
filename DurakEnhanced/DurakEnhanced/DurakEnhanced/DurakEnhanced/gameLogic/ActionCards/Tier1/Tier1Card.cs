using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DurakEnhanced.gameLogic.ActionCards.Tier1
{
    public class Tier1Card1 : ActionCard
    {
        private readonly PictureBox slot2Box;
        private readonly Image cardToReveal;
        private readonly Image backImage;

        public Tier1Card1(PictureBox slot2Box, Image cardToReveal, Image backImage)
            : base("Reveal Slot 2")
        {
            this.slot2Box = slot2Box;
            this.cardToReveal = cardToReveal;
            this.backImage = backImage;
        }

        public override void Execute()
        {
            Console.WriteLine("[Tier1Card1] Revealing opponent's slot 2 card...");

            slot2Box.SizeMode = PictureBoxSizeMode.StretchImage;
            slot2Box.Image = cardToReveal;

            var timer = new Timer { Interval = 10000 }; // 10 seconds
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                slot2Box.Image = backImage;
                timer.Dispose();
                Console.WriteLine("[Tier1Card1] Reverted slot 2 card to back image.");
            };
            timer.Start();
        }
    }
}
