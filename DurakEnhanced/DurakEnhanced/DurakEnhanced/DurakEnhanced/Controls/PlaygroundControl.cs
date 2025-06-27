using DurakEnhanced;
using DurakEnhanced.Forms;
using DurakEnhanced.GameLogic;
using DurakEnhanced.gameLogic;
using DurakEnhanced.gameLogic.ActionCards;
using DurakEnhanced.gameLogic.ActionCards.Tier1;
using DurakEnhanced.gameLogic.ActionCards.Troll;
using DurakEnhanced.gameLogic.ActionCards.Visual;
using DurakEnhanced.Helpers;
using DurakEnhanced.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DurakEnhanced.Controls
{
    public partial class PlaygroundControl : UserControl
    {
        private MainForm mainForm;
        private NetworkManager networkManager;
        private IngamePopupControl popupMenu;
        private PopupAnimator popupAnimator;
        private GameEngine gameEngine;
        private FlowLayoutPanel cardPanel;
        private FlowLayoutPanel opponentCardPanel;
        private FlowLayoutPanel battlefieldPanel;
        private readonly bool isHost;
        private Suit trumpSuit;
        private List<Card> localHand = new List<Card>();
        private List<Card> opponentHand;
        private bool isClientTurn;
        private GameState gameState;
        private Button finishAttackButton;
        private IDiceRoller diceRoller = new DiceRoller();
        private DiceRollerControl diceRollerControl;
        private FlowLayoutPanel actionCardPanel;
        private List<ActionCard> actionCards = new List<ActionCard>();

        public PlaygroundControl(MainForm mainForm, NetworkManager networkManager, bool isHost)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkManager = networkManager;
            this.isHost = isHost;
            this.networkManager.MessageReceived += NetworkManager_MessageReceived;
            if (isHost)
            {
                InitializeGame(); // Only the host initializes the full game logic
            }
            else
            {
                this.networkManager.MessageReceived += NetworkManager_MessageReceived;
            }
        

            var trollCard = new TrollCard1(this);
            actionCards.Add(trollCard);
            var backImage = Properties.Resources.backofcard;
            var revealedCard = Properties.Resources.Hearts_5_white;
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {
            // Initialize the DiceRollerControl
            diceRollerControl = new DiceRollerControl
            {
                Size = new Size(600, 400),
                Visible = false
            };
            this.Controls.Add(diceRollerControl);
            this.Controls.SetChildIndex(diceRollerControl, 0);

            // Initialize Action Card Panel
            actionCardPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Location = new Point(this.ClientSize.Width - 310, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Red
            };
            this.Controls.Add(actionCardPanel);

            // Popup Menu Setup
            this.Padding = new Padding(0, 0, 0, 80);
            SetupCardPanels();
            CenterGameImage();

            this.Resize += (s, evt) =>
            {
                CenterCardPanel();
                AdjustCardPanelHeight();

                if (isHost && gameEngine != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        DisplayPlayerHand(gameEngine.Host.Hand);
                    }));
                }
            };

            this.Resize += (s, evt2) => CenterGameImage();
            this.Resize += (s, evt3) => CenterOpponentCards();

            if (isHost && gameEngine != null)
            {
                DisplayPlayerHand(gameEngine.Host.Hand);
                UpdateOpponentCards(gameEngine.CurrentDefender.Hand);
                SetupBattlefieldSlots();
            }

            finishAttackButton = new Button
            {
                Text = "Finish Attack",
                Visible = isHost, // Only attacker (host initially) sees it
                AutoSize = true,
                Location = new Point(10, this.Height - 50), // Adjust as needed
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };

            finishAttackButton.Click += FinishAttackButton_Click;
            this.Controls.Add(finishAttackButton);

            Button takeCardsButton = new Button();
            takeCardsButton.Text = "Take Cards";
            takeCardsButton.Location = new Point(10, 10); // adjust position as needed
            takeCardsButton.Click += TakeCardsButton_Click;
            takeCardsButton.Visible = !isHost; // Only visible on client
            Controls.Add(takeCardsButton);

            popupMenu = new IngamePopupControl { Visible = false };
            this.Controls.Add(popupMenu);
            this.Controls.SetChildIndex(popupMenu, 0);

            popupAnimator = new PopupAnimator(popupMenu);
            popupMenu.OnLeaveGameRequested = () =>
            {
                networkManager?.StopServer();
                mainForm.LoadScreen(new MainMenuControl(mainForm));
            };

            // Give player a card
            
            DisplayActionCards();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            networkManager?.StopServer(); // Sluit netjes af bij exit
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void FinishAttackButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[Host] Finish Attack button clicked.");

            if (!isHost) return;
            if (gameEngine.CurrentAttacker != gameEngine.Host) return;

            bool allDefended = gameEngine.CurrentRound.All(pair => pair.Item2 != null);

            if (allDefended)
            {
                gameEngine.EndRound();

                string updatedGuestHandJson = JsonConvert.SerializeObject(gameEngine.Guest.Hand);
                networkManager.SendToClient("UpdateHand|" + updatedGuestHandJson);

                DisplayPlayerHand(gameEngine.Host.Hand);
                UpdateOpponentCards(gameEngine.Guest.Hand);
                SetupBattlefieldSlots();

                isClientTurn = true;
                networkManager.SendToClient("NextRound|");
                Console.WriteLine("[Host] All cards defended. Proceeding to next round.");
            }
            else
            {
                MessageBox.Show("Some attacks are not defended yet!");
                Console.WriteLine("[Host] Attack not fully defended.");
            }
        }

        private void TakeCardsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[Client] Take Cards button clicked.");

            foreach (Panel slot in battlefieldPanel.Controls)
            {
                foreach (Control cardControl in slot.Controls)
                {
                    if (cardControl.Tag is Card card)
                    {
                        localHand.Add(card);
                    }
                }
                slot.Controls.Clear();
            }

            DisplayPlayerHand(localHand);

            networkManager?.SendMessage("DefenderTookCards");
            Console.WriteLine("[Client] Sent DefenderTookCards to host.");
        }



        private void NetworkManager_MessageReceived(string message)
        {
            Console.WriteLine($"[Network] Message received: {message}");

            if (InvokeRequired)
            {
                Console.WriteLine("[Network] Invoke required. Re-invoking on UI thread.");
                Invoke(new Action(() => NetworkManager_MessageReceived(message)));
                return;
            }

            if (message.StartsWith("InitGame|"))
            {
                Console.WriteLine("[Network] InitGame message received.");
                string json = message.Substring("InitGame|".Length);
                InitializeGameForClient(json);
            }
            else if (message.StartsWith("PlayCard|"))
            {
                Console.WriteLine("[Network] PlayCard message received.");
                string[] parts = message.Split('|');
                if (parts.Length != 5)
                {
                    Console.WriteLine("[Network] Invalid PlayCard message format.");
                    MessageBox.Show("Invalid PlayCard message format.");
                    return;
                }

                string rankStr = parts[1];
                string suitStr = parts[2];
                int slotIndex = int.Parse(parts[3]);
                string action = parts[4];

                Console.WriteLine($"[Network] Parsed card: {rankStr} of {suitStr}, Slot: {slotIndex}, Action: {action}");

                if (!Enum.TryParse(rankStr, out Rank rank) || !Enum.TryParse(suitStr, out Suit suit))
                {
                    Console.WriteLine("[Network] Invalid rank or suit.");
                    MessageBox.Show("Invalid rank or suit.");
                    return;
                }

                Card receivedCard = new Card(suit, rank);

                if (slotIndex < 0 || slotIndex >= battlefieldPanel.Controls.Count)
                {
                    Console.WriteLine("[Network] Invalid slot index.");
                    MessageBox.Show("Invalid slot index.");
                    return;
                }

                var slot = battlefieldPanel.Controls[slotIndex] as Panel;
                if (slot == null)
                {
                    Console.WriteLine("[Network] Slot panel not found.");
                    return;
                }

                var cardImage = CardUIHelper.CreateCardImageOnly(receivedCard);
                cardImage.Tag = receivedCard;

                if (action == "attack")
                {
                    Console.WriteLine("[Network] Applying attack move visually.");
                    slot.Controls.Clear();
                    slot.Controls.Add(cardImage);

                    opponentHand.RemoveAll(c => c.Rank == rank && c.Suit == suit);
                    UpdateOpponentCards(opponentHand);

                    isClientTurn = true;
                    Console.WriteLine("[Network] Client's turn set to TRUE (can now defend).");
                }
                else if (action == "defend")
                {
                    Console.WriteLine("[Network] Applying defense move visually.");
                    if (slot.Controls.Count == 0 || !(slot.Controls[0].Tag is Card attackCard))
                    {
                        Console.WriteLine("[Network] No attack card in slot. Defense rejected.");
                        MessageBox.Show("No valid attack card found.");
                        return;
                    }

                    cardImage.Location = new Point(0, 30);
                    slot.Controls.Add(cardImage);

                    string attackStr = attackCard != null ? $"{attackCard.Rank} of {attackCard.Suit}" : "null";
                    string defendStr = receivedCard != null ? $"{receivedCard.Rank} of {receivedCard.Suit}" : "null";
                    Console.WriteLine($"[Host] Trying to defend: {defendStr} against {attackStr}");

                    bool success = gameEngine.Defend(attackCard, receivedCard);
                    Console.WriteLine($"[Network] Defense game logic result: {success}");

                    if (!success)
                    {
                        Console.WriteLine("[Network] Defense rejected by game logic.");
                        MessageBox.Show("Defense rejected.");
                        return;
                    }

                    // Create and position defense card relative to attack card
                    var attackControl = slot.Controls[0];
                    var defenseImage = CardUIHelper.CreateCardImageOnly(receivedCard);
                    defenseImage.Tag = receivedCard;
                    defenseImage.Location = new Point(attackControl.Location.X + 20, attackControl.Location.Y + 30); // offset
                    slot.Controls.Add(defenseImage);
                    defenseImage.BringToFront();

                    string confirmMsg = $"DefendConfirmed|{receivedCard.Rank}|{receivedCard.Suit}";
                    networkManager?.SendToClient(confirmMsg);
                    Console.WriteLine("[Network] Sent DefendConfirmed message to client.");

                    var toRemove = gameEngine.Guest.Hand.FirstOrDefault(c => c.Suit == suit && c.Rank == rank);
                    if (toRemove != null)
                    {
                        gameEngine.Guest.Hand.Remove(toRemove);
                        UpdateOpponentCards(gameEngine.Guest.Hand); // ✅ Update visual deck
                    }

                    isClientTurn = false;
                    Console.WriteLine("[Network] Client's turn set to FALSE.");
                }
            }
            else if (message.StartsWith("DefendConfirmed|"))
            {
                Console.WriteLine("[Network] DefendConfirmed message received.");
                string[] parts = message.Split('|');
                if (parts.Length != 3)
                {
                    Console.WriteLine("[Network] Invalid DefendConfirmed format.");
                    return;
                }

                string rankStr = parts[1];
                string suitStr = parts[2];

                if (Enum.TryParse(rankStr, out Rank rank) && Enum.TryParse(suitStr, out Suit suit))
                {
                    var toRemove = localHand.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);
                    if (toRemove != null)
                    {
                        Console.WriteLine("[Network] Removing confirmed defender card from hand.");
                        localHand.Remove(toRemove);
                        DisplayPlayerHand(localHand);
                    }

                }

                else
                {
                    Console.WriteLine("[Network] Failed to parse rank or suit in DefendConfirmed.");
                }
            }
            else if (message.StartsWith("NextRound"))
            {
                Console.WriteLine("[Client] Received NextRound. Resetting battlefield and updating hands.");

                // 1. Clear battlefield visuals
                SetupBattlefieldSlots();

                // 2. Redisplay own hand
                DisplayPlayerHand(localHand);

                // 3. Update opponent’s cards (still just backs)
                UpdateOpponentCards(opponentHand);

                // 4. Re-enable client move
                isClientTurn = true;
            }
            else if (message.StartsWith("UpdateHand|"))
            {
                string json = message.Substring("UpdateHand|".Length);
                try
                {
                    localHand = JsonConvert.DeserializeObject<List<Card>>(json);
                    DisplayPlayerHand(localHand);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[Client] Failed to update hand: " + ex.Message);
                }
            }
            else if (message == "DefenderTookCards")
            {
                Console.WriteLine("[Network] Client took cards. Clearing battlefield on host.");

                // Clear all cards from the battlefield on host UI
                foreach (Panel slot in battlefieldPanel.Controls)
                {
                    slot.Controls.Clear();
                }

                // Reset for next round
                gameEngine.EndRound(); // ✅ Ensures roles, decks, timer, etc. are updated

                UpdateOpponentCards(gameEngine.Guest.Hand);
                DisplayPlayerHand(gameEngine.Host.Hand);
            }
            else
            {
                Console.WriteLine("[Network] Unrecognized message: " + message);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!popupMenu.Visible)
                {
                    popupMenu.BringToFront();
                    var centerX = (this.Width - popupMenu.Width) / 2;
                    popupMenu.Left = centerX;
                    popupAnimator.Start(-popupMenu.Height, (this.Height - popupMenu.Height) / 2);
                }
                else
                {
                    popupMenu.Visible = false;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitializeGame()
        {
            var host = new Player { Name = "Host" };
            var guest = new Player { Name = "Guest" };
            gameEngine = new GameEngine { Host = host, Guest = guest };
            gameEngine.StartGame();

            var gameData = new
            {
                HostHand = gameEngine.Host.Hand,
                GuestHand = gameEngine.Guest.Hand,
                TrumpSuit = gameEngine.TrumpSuit.ToString(),
                FirstAttacker = gameEngine.CurrentAttacker.Name
            };

            string json = JsonConvert.SerializeObject(gameData);
            networkManager.SendToClient("InitGame|" + json);

            Console.WriteLine("Game started. Trump: " + gameEngine.TrumpSuit);
            Console.WriteLine("Host cards: " + string.Join(", ", host.Hand));
            Console.WriteLine("Guest cards: " + string.Join(", ", guest.Hand));
        }

        private void InitializeGameForClient(string json)
        {
            try
            {
                var gameData = JsonConvert.DeserializeObject<dynamic>(json);

                var hostHand = JsonConvert.DeserializeObject<List<Card>>(gameData.HostHand.ToString());
                var guestHand = JsonConvert.DeserializeObject<List<Card>>(gameData.GuestHand.ToString());
                var trumpSuit = (Suit)Enum.Parse(typeof(Suit), gameData.TrumpSuit.ToString());
                string firstAttacker = gameData.FirstAttacker.ToString();

                this.trumpSuit = trumpSuit;
                this.localHand = guestHand;
                this.opponentHand = hostHand;
                this.isClientTurn = (firstAttacker == "Guest");

                DisplayPlayerHand(localHand);
                UpdateOpponentCards(opponentHand);
                SetupBattlefieldSlots();

               
                Console.WriteLine("==== Game Data Received from Host ====");
                Console.WriteLine("Trump Suit: " + trumpSuit);
                Console.WriteLine("First Attacker: " + firstAttacker);
                Console.WriteLine("Guest (My) Hand:");
                foreach (var card in guestHand)
                    Console.WriteLine($"- {card}");

                Console.WriteLine("Host (Opponent) Card Count: " + hostHand.Count);
                Console.WriteLine("======================================");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize game on client:\n" + ex.Message);
            }
        }

        private void SetupCardPanels()
        {
            opponentCardPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            this.Controls.Add(opponentCardPanel);
            this.Controls.SetChildIndex(opponentCardPanel, 0);

            cardPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.Transparent
            };
            this.Controls.Add(cardPanel);
            this.Controls.SetChildIndex(cardPanel, 0);
            this.BeginInvoke(new Action(() => { AdjustCardPanelHeight(); CenterCardPanel(); }));

            battlefieldPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                AllowDrop = true,
                BackColor = Color.FromArgb(20, 20, 20),
                Padding = new Padding(10),
                Margin = new Padding(10)
            };
            battlefieldPanel.DragEnter += BattlefieldPanel_DragEnter;
            battlefieldPanel.DragDrop += BattlefieldPanel_DragDrop;

            this.Controls.Add(battlefieldPanel);
            this.Controls.SetChildIndex(battlefieldPanel, 0);

        }

        private void DisplayPlayerHand(List<Card> hand)
        {
            cardPanel.Controls.Clear();

            foreach (var card in hand)
            {
                var btn = CardUIHelper.CreatePlayerCardButton(card);
                cardPanel.Controls.Add(btn);
            }

            this.BeginInvoke(new Action(CenterCardPanel));
        }

        private void UpdateOpponentCards(List<Card> opponentHand)
        {
            opponentCardPanel.Controls.Clear();
            foreach (var _ in opponentHand)
            {
                opponentCardPanel.Controls.Add(CardUIHelper.CreateOpponentCardBack());
            }

            this.BeginInvoke(new Action(() =>
            {
                opponentCardPanel.PerformLayout();
                CenterOpponentCards();
            }));
        }

        private void CenterCardPanel()
        {
            cardPanel.Location = new Point(
            (this.ClientSize.Width - cardPanel.PreferredSize.Width) / 2,
            this.ClientSize.Height - cardPanel.PreferredSize.Height - 10
            );
        }

        private void AdjustCardPanelHeight()
        {
            int maxCardHeight = 199;
            cardPanel.Size = new Size(this.ClientSize.Width, maxCardHeight);
        }

        private void CenterOpponentCards()
        {
            if (opponentCardPanel == null) return;
            int x = (this.ClientSize.Width - opponentCardPanel.PreferredSize.Width) / 2;
            opponentCardPanel.Location = new Point(x, 20);
        }

        private void CenterGameImage()
        {
            if (pictureBox1 == null) return;
            int x = (this.ClientSize.Width - pictureBox1.Width) / 2;
            int y = (this.ClientSize.Height - pictureBox1.Height) / 2;
            pictureBox1.Location = new Point(x, y);
        }

        private void BattlefieldPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void BattlefieldPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
            {
                var card = e.Data.GetData(typeof(Card)) as Card;
                var btn = CardUIHelper.CreateBattlefieldCardButton(card);
                battlefieldPanel.Controls.Add(btn);
            }
        }

        private void SetupBattlefieldSlots()
        {
            // Remove existing panel if already added (to support resize/reinit)
            if (battlefieldPanel != null)
                this.Controls.Remove(battlefieldPanel);

            battlefieldPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                Location = new Point((this.Width - 600) / 2, this.Height / 2 - 100),
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            for (int i = 0; i < 6; i++)
            {
                var slot = CreateBattlefieldSlot();
                battlefieldPanel.Controls.Add(slot);
            }

            this.Controls.Add(battlefieldPanel);
            this.Controls.SetChildIndex(battlefieldPanel, 0);
        }

        private Panel CreateBattlefieldSlot()
        {
            var slot = new Panel
            {
                Size = new Size(135, 199),
                AllowDrop = true,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10)
            };

            slot.DragEnter += BattlefieldSlot_DragEnter;
            slot.DragDrop += BattlefieldSlot_DragDrop;

            return slot;
        }

        private void BattlefieldSlot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
                e.Effect = DragDropEffects.Move;
        }

        private void BattlefieldSlot_DragDrop(object sender, DragEventArgs e)
        {
            Card droppedCard = e.Data.GetData(typeof(Card)) as Card;
            if (droppedCard == null)
            {
                Console.WriteLine("[DragDrop] DroppedCard was null.");
                return;
            }

            var slot = sender as Panel;
            int slotIndex = battlefieldPanel.Controls.IndexOf(slot);
            Console.WriteLine($"[DragDrop] Dropped card: {droppedCard.Rank} of {droppedCard.Suit}");
            Console.WriteLine($"[DragDrop] isHost: {isHost}, isClientTurn: {isClientTurn}, SlotIndex: {slotIndex}");

            if (isHost)
            {
                bool isHostTurn = gameEngine.CurrentAttacker == gameEngine.Host;
                Console.WriteLine($"[Host] Host turn? {isHostTurn}");

                if (!isHostTurn)
                {
                    Console.WriteLine("[Host] Not host's turn to attack.");
                    MessageBox.Show("It's not your turn to attack.");
                    return;
                }

                if (slot.Controls.Count > 0)
                {
                    Console.WriteLine("[Host] Slot already occupied.");
                    MessageBox.Show("This slot is already used.");
                    return;
                }

                bool success = gameEngine.Attack(droppedCard);
                Console.WriteLine($"[Host] Attack success? {success}");

                if (!success)
                {
                    MessageBox.Show("Invalid attack move.");
                    return;
                }

                var cardImage = CardUIHelper.CreateCardImageOnly(droppedCard);
                cardImage.Tag = droppedCard; // ✅ attach card info for future defense

                slot.Controls.Clear();
                slot.Controls.Add(cardImage); // ✅ use the tagged cardImage
                DisplayPlayerHand(gameEngine.Host.Hand);

                string msg = $"PlayCard|{droppedCard.Rank}|{droppedCard.Suit}|{slotIndex}|attack";
                Console.WriteLine($"[Host] Sending to client: {msg}");
                networkManager?.SendToClient(msg);
            }
            else // Client defending
            {
                Console.WriteLine($"[Client] Attempting to defend in slot {slotIndex}");

                if (!isClientTurn)
                {
                    Console.WriteLine("[Client] Not client’s turn.");
                    MessageBox.Show("It's not your turn.");
                    return;
                }

                if (slot.Controls.Count == 0)
                {
                    Console.WriteLine("[Client] Slot is empty, cannot defend.");
                    MessageBox.Show("You must defend against an existing attack.");
                    return;
                }

                if (!(slot.Controls[0].Tag is Card attackCard))
                {
                    Console.WriteLine("[Client] Slot does not contain a valid attack card.");
                    MessageBox.Show("You must defend against an existing attack.");
                    return;
                }

                string msg = $"PlayCard|{droppedCard.Rank}|{droppedCard.Suit}|{slotIndex}|defend";
                Console.WriteLine($"[Client] Sending to host: {msg}");
                networkManager?.SendMessage(msg);

                // We wait for confirmation from host before removing from hand
            }
        }

        private void rollDiceButton_Click(object sender, EventArgs e)
        {
            // Center the DiceRollerControl within PlaygroundControl
            diceRollerControl.Left = (this.Width - diceRollerControl.Width) / 2;
            diceRollerControl.Top = (this.Height - diceRollerControl.Height) / 2;
            diceRollerControl.BringToFront();
            diceRollerControl.Visible = true;

            diceRollerControl.RollD20(result =>
            {
                rollResultLabel.Text = $"You rolled: {result}";
            });
        }

        private void DisplayActionCards()
        {
            actionCardPanel.Controls.Clear();

            // Create a shallow copy of the list to avoid modification issues
            var cardsToDisplay = actionCards.ToList();

            foreach (var card in cardsToDisplay)
            {
                var btn = new Button
                {
                    Text = card.Name,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                btn.Click += (s, e) =>
                {
                    Console.WriteLine($"[Click] Executing card: {card.Name}");
                    Console.WriteLine($"[Click] Cards before: {actionCards.Count}");
                    card.Execute();

                    bool removed = actionCards.Remove(card);
                    Console.WriteLine($"[Click] Removed: {removed}");
                    Console.WriteLine($"[Click] Cards after: {actionCards.Count}");

                    DisplayActionCards();
                };

                actionCardPanel.Controls.Add(btn);
            }
        }

        private void rollResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}