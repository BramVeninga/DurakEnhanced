using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.gameLogic.ActionCards
{
    public class DiceRoller : IDiceRoller
    {
        private readonly Random _random;

        public DiceRoller()
        {
            _random = new Random();
        }

        public int Roll(int sides)
        {
            return _random.Next(1, sides + 1);
        }
    }
}
