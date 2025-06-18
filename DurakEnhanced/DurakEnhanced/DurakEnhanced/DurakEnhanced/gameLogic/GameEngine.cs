using DurakEnhanced.gameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;


namespace DurakEnhanced.GameLogic
{
    public class GameEngine
    {
        public List<Card> Deck { get; private set; } = new List<Card>();
        public List<Tuple<Card, Card>> CurrentRound { get; private set; } = new List<Tuple<Card, Card>>();

        public Player Host { get; set; }
        public Player Guest { get; set; }

        public Player CurrentAttacker { get; private set; }
        public Player CurrentDefender { get; private set; }

        public Suit TrumpSuit { get; private set; }

        public bool IsGameOver
        {
            get { return Host.Hand.Count == 0 || Guest.Hand.Count == 0; }
        }

        private readonly Random rng = new Random();

        private Timer moveTimer;

        private const int MoveTimeoutMilliseconds = 60000; // 60 seconds


        public void StartGame()
        {
            CreateDeck();
            ShuffleDeck();
            DealCards();

            TrumpSuit = Deck[Deck.Count - 1].Suit;

            CurrentAttacker = Host;
            CurrentDefender = Guest;

            StartMoveTimer();
        }

        private void CreateDeck()
        {
            Deck.Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (Rank rank = Rank.Six; rank <= Rank.Ace; rank++)
                {
                    Deck.Add(new Card(suit, rank));
                }
            }
        }

        private void ShuffleDeck()
        {
            Deck = Deck.OrderBy(_ => rng.Next()).ToList();
        }

        private Card DrawCard()
        {
            if (Deck.Count == 0)
                return null;

            var card = Deck[0];
            Deck.RemoveAt(0);
            return card;
        }

        private void DealCards()
        {
            for (int i = 0; i < 6; i++)
            {
                var hostCard = DrawCard();
                if (hostCard != null)
                    Host.Hand.Add(hostCard);
                var guestCard = DrawCard();
                if (guestCard != null)
                    Guest.Hand.Add(guestCard);
            }
        }

        public bool Attack(Card card)
        {
            if (!Host.Hand.Contains(card) && !Guest.Hand.Contains(card))
                return false;

            List<Card> allCards = new List<Card>();
            foreach (var pair in CurrentRound)
            {
                allCards.Add(pair.Item1);
                if (pair.Item2 != null)
                    allCards.Add(pair.Item2);
            }

            if (CurrentRound.Count > 0 &&
                !DurakRules.IsValidAttackCard(card, allCards))
                return false;
            moveTimer?.Stop();
            CurrentAttacker.Hand.Remove(card);
            CurrentRound.Add(new Tuple<Card, Card>(card, null));
            return true;
        }

        public bool Defend(Card attackCard, Card defendCard)
        {
            if (!CurrentDefender.Hand.Contains(defendCard))
                return false;

            if (!DurakRules.Beats(defendCard, attackCard, TrumpSuit))
                return false;

            int index = -1;
            for (int i = 0; i < CurrentRound.Count; i++)
            {
                if (CurrentRound[i].Item1 == attackCard && CurrentRound[i].Item2 == null)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                return false;

            moveTimer?.Stop();
            CurrentRound[index] = new Tuple<Card, Card>(attackCard, defendCard);
            CurrentDefender.Hand.Remove(defendCard);
            return true;
        }

        private void SwapRoles()
        {
            var temp = CurrentAttacker;
            CurrentAttacker = CurrentDefender;
            CurrentDefender = temp;
        }

        public void EndRound()
        {
            bool allDefended = true;
            foreach (var pair in CurrentRound)
            {
                if (pair.Item2 == null)
                {
                    allDefended = false;
                    break;
                }
            }

            if (!allDefended)
            {
                // Defender takes all cards
                foreach (var pair in CurrentRound)
                {
                    CurrentDefender.Hand.Add(pair.Item1);
                    if (pair.Item2 != null)
                        CurrentDefender.Hand.Add(pair.Item2);
                }
                // Roles stay the same
            }
            else
            {
                SwapRoles();
            }

            CurrentRound.Clear();
            StartMoveTimer();
        }

        public void StartMoveTimer()
        {
            if (moveTimer != null)
                moveTimer.Elapsed -= OnMoveTimeout; // Prevent duplicate attachment

            moveTimer?.Stop();
            moveTimer = new Timer(MoveTimeoutMilliseconds);
            moveTimer.Elapsed += OnMoveTimeout;
            moveTimer.AutoReset = false;
            moveTimer.Start();
        }

        private void OnMoveTimeout(object sender, ElapsedEventArgs e)
        {
            moveTimer.Stop();
            Console.WriteLine($"Timeout! {CurrentAttacker.Name} took too long.");
            SwapRoles();
            CurrentRound.Clear();

        }

    }
}
