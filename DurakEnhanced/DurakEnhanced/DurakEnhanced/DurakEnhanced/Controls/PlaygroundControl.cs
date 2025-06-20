using DurakEnhanced.Forms;
using DurakEnhanced.gameLogic;
using DurakEnhanced.GameLogic;
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

        public PlaygroundControl(MainForm mainForm, NetworkManager networkManager, bool isHost)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.networkManager = networkManager;
            this.isHost = isHost;

            if (isHost)
            {
                InitializeGame(); // Only the host initializes the full game logic
                this.networkManager.MessageReceived += NetworkManager_MessageReceived;
            }
            else
            {
                this.networkManager.MessageReceived += NetworkManager_MessageReceived;
            }
        }

        private void PlaygroundControl_Load(object sender, EventArgs e)
        {
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

            popupMenu = new IngamePopupControl { Visible = false };
            this.Controls.Add(popupMenu);
            this.Controls.SetChildIndex(popupMenu, 0);

            popupAnimator = new PopupAnimator(popupMenu);
            popupMenu.OnLeaveGameRequested = () =>
            {
                networkManager?.StopServer();
                mainForm.LoadScreen(new MainMenuControl(mainForm));
            };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            networkManager?.StopServer(); // Sluit netjes af bij exit
            mainForm.LoadScreen(new MainMenuControl(mainForm));
        }

        private void NetworkManager_MessageReceived(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => NetworkManager_MessageReceived(message)));
                return;
            }

            if (message.StartsWith("InitGame|"))
            {
                string json = message.Substring("InitGame|".Length);
                InitializeGameForClient(json); 
            }
            else
            {
                Console.WriteLine("[Received] " + message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!popupMenu.Visible)
                {
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
                BorderStyle = BorderStyle.FixedSingle,
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
            if (droppedCard == null) return;

            bool isHostTurn = gameEngine.CurrentAttacker == gameEngine.Host;

            if (!isHostTurn)
            {
                MessageBox.Show("It's not your turn to attack.");
                return;
            }

            bool success = gameEngine.Attack(droppedCard);
            if (!success)
            {
                MessageBox.Show("Invalid attack move.");
                return;
            }

            if (success)
            {
                var cardImage = CardUIHelper.CreateCardImageOnly(droppedCard);
                var slot = sender as Panel;

                // Prevent placing into a used slot
                if (slot.Controls.Count > 0)
                {
                    MessageBox.Show("This slot is already used.");
                    return;
                }

                slot.Controls.Clear();
                slot.Controls.Add(cardImage);
                DisplayPlayerHand(gameEngine.Host.Hand);
            }
            else
            {
                MessageBox.Show("Attack failed due to game logic.");
            }
        }

    }
}