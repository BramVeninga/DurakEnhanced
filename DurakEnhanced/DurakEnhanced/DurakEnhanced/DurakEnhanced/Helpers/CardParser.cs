using DurakEnhanced.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakEnhanced.Helpers
{
    public static class CardParser
    {
        public static Card FromShortString(string cardCode)
        {
            if (string.IsNullOrWhiteSpace(cardCode))
                throw new ArgumentException("Invalid card code.");

            // Extract suit name from end
            string suitPart = ExtractSuitPart(cardCode);
            string rankPart = cardCode.Replace(suitPart, "");

            Rank rank = ParseRank(rankPart);
            Suit suit = ParseSuit(suitPart);

            return new Card(suit, rank);
        }

        private static string ExtractSuitPart(string cardCode)
        {
            // Match longest suit name from known ones
            string[] knownSuits = { "Hearts", "Tiles", "Clovers", "Pikes" };
            foreach (var suit in knownSuits)
            {
                if (cardCode.EndsWith(suit))
                    return suit;
            }
            throw new ArgumentException("Invalid suit part in card code: " + cardCode);
        }

        private static Rank ParseRank(string code)
        {
            if (code == "6") return Rank.Six;
            if (code == "7") return Rank.Seven;
            if (code == "8") return Rank.Eight;
            if (code == "9") return Rank.Nine;
            if (code == "10") return Rank.Ten;
            if (code == "Jack") return Rank.Jack;
            if (code == "Queen") return Rank.Queen;
            if (code == "King") return Rank.King;
            if (code == "A") return Rank.Ace;

            throw new ArgumentException("Unknown rank: " + code);
        }

        private static Suit ParseSuit(string code)
        {
            if (code == "Hearts") return Suit.Hearts;
            if (code == "Clovers") return Suit.Clubs;
            if (code == "Tiles") return Suit.Diamonds;
            if (code == "Pikes") return Suit.Spades;

            throw new ArgumentException("Unknown suit: " + code);
        }
    }
}
