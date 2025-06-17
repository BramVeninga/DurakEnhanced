using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakTCPTest.gameLogic
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public override string ToString() => $"{Rank} of {Suit}";
    }

}
