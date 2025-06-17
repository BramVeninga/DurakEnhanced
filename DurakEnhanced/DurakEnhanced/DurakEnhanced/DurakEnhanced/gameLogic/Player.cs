using DurakEnhanced.GameLogic;
using System.Collections.Generic;

namespace DurakEnhanced.gameLogic
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public List<ActionCard> ActionCards { get; set; }

        public bool HasCards => Hand != null && Hand.Count > 0;

        public Player()
        {
            Hand = new List<Card>();
            ActionCards = new List<ActionCard>();
        }
    }

}
