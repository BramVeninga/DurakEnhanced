using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakTCPTest.gameLogic
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new();
        public List<ActionCard> ActionCards { get; set; } = new();

        public bool HasCards => Hand.Count > 0;
    }

}
