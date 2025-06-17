using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakTCPTest.gameLogic
{
    public static class DurakRules
    {
        public static bool CanDefend(Card attack, Card defend, Suit trumpSuit)
        {
            if (attack.Suit == defend.Suit && defend.Value > attack.Value)
                return true;

            if (defend.Suit == trumpSuit && attack.Suit != trumpSuit)
                return true;

            return false;
        }

        public static bool CanAddToAttack(List<(Card Attack, Card? Defense)> currentRound, Card newCard)
        {
            // Je mag aanvallen met kaarten die gelijk zijn aan reeds gespeelde waarden
            return currentRound.Any(pair => pair.Attack.Value == newCard.Value || (pair.Defense != null && pair.Defense.Value == newCard.Value));
        }

        public static bool IsRoundOver(List<(Card Attack, Card? Defense)> currentRound)
        {
            // Ronde is over als alle aanvallen verdedigd zijn
            return currentRound.All(pair => pair.Defense != null);
        }
    }

}
