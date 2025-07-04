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
            WebSocketServerHandler.OnMessageReceived += (msg) =>
            {
                MessageReceived?.Invoke(msg);
            };

            WebSocketServerHandler.Start(port);
        }

        public void StopServer()
        {
            WebSocketServerHandler.Stop();
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
            WebSocketServerHandler.SendToAllClients(message);
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
