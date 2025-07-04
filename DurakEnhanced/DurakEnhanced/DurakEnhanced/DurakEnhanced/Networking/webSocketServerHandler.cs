using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DurakEnhanced.Networking
{
    public static class WebSocketServerHandler
    {
        private static WebSocketServer server;
        private static GameBehavior gameBehavior;

        public static event Action<string> OnMessageReceived;

        public static void Start(int port)
        {
            server = new WebSocketServer(port);

            // Voeg service toe en bewaar referentie naar GameBehavior
            server.AddWebSocketService<GameBehavior>("/game", () =>
            {
                gameBehavior = new GameBehavior();
                gameBehavior.MessageReceived += (msg) =>
                {
                    OnMessageReceived?.Invoke(msg);
                };
                return gameBehavior;
            });

            server.Start();
        }

        public static void SendToAllClients(string message)
        {
            gameBehavior?.SendToAll(message);
        }

        public static void Stop()
        {
            server?.Stop();
        }

        // ✅ Subclass voor behavior
        private class GameBehavior : WebSocketBehavior
        {
            public event Action<string> MessageReceived;

            protected override void OnMessage(MessageEventArgs e)
            {
                MessageReceived?.Invoke(e.Data);
            }

            public void SendToAll(string message)
            {
                foreach (var id in Sessions.ActiveIDs)
                {
                    Sessions.SendTo(message, id);
                }
            }
        }
    }
}
