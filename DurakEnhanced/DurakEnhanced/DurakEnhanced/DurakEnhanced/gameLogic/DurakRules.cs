using System.Collections.Generic;

namespace DurakEnhanced.GameLogic
{
    public static class DurakRules
    {
        /// <summary>
        /// Determines if cardA beats cardB, given the trump suit.
        /// </summary>
        public static bool Beats(Card cardA, Card cardB, Suit trumpSuit)
        {
            if (cardA.Suit == cardB.Suit)
                return cardA.Rank > cardB.Rank;

            if (cardA.Suit == trumpSuit && cardB.Suit != trumpSuit)
                return true;

            return false;
        }

        /// <summary>
        /// Determines if a card is valid to add to the current trick on the table.
        /// A card is valid if its rank matches any card in the current trick.
        /// </summary>
        public static bool IsValidAttackCard(Card newCard, List<Card> currentCardsOnTable)
        {
            foreach (var card in currentCardsOnTable)
            {
                if (newCard.Rank == card.Rank)
                    return true;
            }
            return currentCardsOnTable.Count == 0; // The first card is always allowed
        }
    }
}
