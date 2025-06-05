using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DurakEnhanced.Networking
{
    public class NetworkManager
    {
        public TcpListener Server { get; private set; }
        public TcpClient Client { get; private set; }

        public event Action<string> MessageReceived;

        public void StartServer(int port)
        {
            Server = new TcpListener(IPAddress.Any, port);
            Server.Start();
            Server.BeginAcceptTcpClient(HandleClientConnected, null);
        }

        private void HandleClientConnected(IAsyncResult result)
        {
            Client = Server.EndAcceptTcpClient(result);
            ListenForMessages(Client);
        }

        public void SendMessage(string message)
        {
            if (Client == null) return;

            var stream = Client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        private void ListenForMessages(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    MessageReceived?.Invoke(message);
                }
            });
        }
    }
}
