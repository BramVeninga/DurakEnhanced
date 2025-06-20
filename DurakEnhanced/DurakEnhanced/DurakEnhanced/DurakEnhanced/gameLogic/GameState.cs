using DurakEnhanced.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.gameLogic
{
    public class GameState
    {
        public List<Card> Deck { get; set; }
        public List<(Card Attack, Card Defense)> CurrentRound { get; set; } // Changed Card? Defense to Card Defense  

        public PlayerState Host { get; set; }
        public PlayerState Guest { get; set; }

        public string TrumpSuit { get; set; }
        public string CurrentAttackerName { get; set; }
        public string CurrentDefenderName { get; set; }

        public string Phase { get; set; } // bv. "Waiting", "Attacking", "Defending", "RoundEnded"  
    }

    public class PlayerState
    {
        public string Name { get; set; }
        public int CardCount { get; set; }
        public List<Card> Hand { get; set; }
        public List<ActionCard> ActionCards { get; set; }
    }

}
