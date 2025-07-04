using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DurakEnhanced.Networking
{
    public class NetworkManager
    {
        private WebSocketClientHandler client;
        private WebSocketServer server;

        public event Action<string> MessageReceived;

        public void StartServer(int port)
        {
            WebSocketServerHandler.OnServerMessageReceived += (msg) =>
            {
                MessageReceived?.Invoke(msg);
            };

            server = WebSocketServerHandler.Start(port);
        }

        public void StopServer()
        {
            server?.Stop();
            server = null;
        }

        public void ConnectToServer(string ip, int port)
        {
            client = new WebSocketClientHandler();
            client.OnMessageReceived += (msg) => MessageReceived?.Invoke(msg);

            // WebSocketSharp expects full URL
            client.Connect($"ws://{ip}:{port}/game");

            client.Send("ClientConnected");
        }

        public void SendMessage(string message)
        {
            client?.Send(message);
        }

        public void SendToClient(string message)
        {
            // WebSocketSharp server pushes automatically to clients when called from WebSocketBehavior
            // We'll need to adjust later if needed. Voor nu dummy.
        }

        public string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public int GetPort()
        {
            return server?.Port ?? -1;
        }
    }
}
