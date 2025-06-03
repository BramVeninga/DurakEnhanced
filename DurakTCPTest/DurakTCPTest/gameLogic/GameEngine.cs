using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakTCPTest.gameLogic
{
    public class GameEngine
    {
        public List<Card> Deck { get; private set; } = new();
        public List<(Card Attack, Card? Defense)> CurrentRound { get; private set; } = new();

        public Player Host { get; set; }
        public Player Guest { get; set; }

        public Player CurrentAttacker { get; private set; }
        public Player CurrentDefender { get; private set; }

        public Suit TrumpSuit { get; private set; }

        public bool IsGameOver => Host.Hand.Count == 0 || Guest.Hand.Count == 0;

        private Random rng = new();

        public void StartGame()
        {
            CreateDeck();
            ShuffleDeck();
            DealCards();

            TrumpSuit = Deck.Last().Suit;

            CurrentAttacker = Host;
            CurrentDefender = Guest;
        }

        private void CreateDeck()
        {
            Deck.Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int value = 6; value <= 14; value++) // 6–Ace
                {
                    Deck.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        private void ShuffleDeck()
        {
            Deck = Deck.OrderBy(c => rng.Next()).ToList();
        }

        private void DealCards()
        {
            for (int i = 0; i < 6; i++)
            {
                Host.Hand.Add(DrawCard());
                Guest.Hand.Add(DrawCard());
            }
        }

        private Card DrawCard()
        {
            if (Deck.Count == 0)
                return null;

            var card = Deck[0];
            Deck.RemoveAt(0);
            return card;
        }

        public bool Attack(Card card)
        {
            if (!CurrentAttacker.Hand.Contains(card))
                return false;

            if (CurrentRound.Count > 0 && !DurakRules.CanAddToAttack(CurrentRound, card))
                return false;

            CurrentAttacker.Hand.Remove(card);
            CurrentRound.Add((card, null));
            return true;
        }

        public bool Defend(Card attackCard, Card defendCard)
        {
            if (!CurrentDefender.Hand.Contains(defendCard))
                return false;

            if (!DurakRules.CanDefend(attackCard, defendCard, TrumpSuit))
                return false;

            var pair = CurrentRound.FirstOrDefault(p => p.Attack == attackCard && p.Defense == null);
            if (pair.Attack == null)
                return false;

            int index = CurrentRound.IndexOf(pair);
            CurrentRound[index] = (attackCard, defendCard);
            CurrentDefender.Hand.Remove(defendCard);
            return true;
        }

        public void EndRound()
        {
            if (!DurakRules.IsRoundOver(CurrentRound))
            {
                // Verdediger moet kaarten pakken
                foreach (var pair in CurrentRound)
                {
                    CurrentDefender.Hand.Add(pair.Attack);
                    if (pair.Defense != null)
                        CurrentDefender.Hand.Add(pair.Defense);
                }
            }

            RefillHands();

            // Beurten wisselen: als verdediging succesvol, dan aanvaller wisselt
            if (DurakRules.IsRoundOver(CurrentRound))
                SwapTurns();

            CurrentRound.Clear();
        }

        private void SwapTurns()
        {
            var temp = CurrentAttacker;
            CurrentAttacker = CurrentDefender;
            CurrentDefender = temp;
        }

        private void RefillHands()
        {
            var players = new[] { Host, Guest };

            foreach (var player in players.OrderBy(p => p == CurrentAttacker ? 0 : 1))
            {
                while (player.Hand.Count < 6 && Deck.Count > 0)
                {
                    player.Hand.Add(DrawCard());
                }
            }
        }

        public GameState GetCurrentState(bool includeHands = false)
        {
            return new GameState
            {
                Deck = new List<Card>(Deck),
                CurrentRound = new List<(Card, Card?)>(CurrentRound),
                Host = new PlayerState
                {
                    Name = Host.Name,
                    CardCount = Host.Hand.Count,
                    Hand = includeHands ? new List<Card>(Host.Hand) : null,
                    ActionCards = new List<ActionCard>() // empty for now
                },
                Guest = new PlayerState
                {
                    Name = Guest.Name,
                    CardCount = Guest.Hand.Count,
                    Hand = includeHands ? new List<Card>(Guest.Hand) : null,
                    ActionCards = new List<ActionCard>() // empty for now
                },
                TrumpSuit = TrumpSuit.ToString(),
                CurrentAttackerName = CurrentAttacker.Name,
                CurrentDefenderName = CurrentDefender.Name,
                Phase = IsGameOver ? "GameOver" : "InProgress"
            };
        }
    }
}
