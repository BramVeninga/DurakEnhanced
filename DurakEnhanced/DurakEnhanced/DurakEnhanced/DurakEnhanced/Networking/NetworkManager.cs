using System;
using System.Collections.Generic;
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

        private readonly List<TcpClient> Clients = new List<TcpClient>();

        public event Action<string> MessageReceived;

        public void StartServer(int port)
        {
            Server = new TcpListener(IPAddress.Any, port);
            Server.Start();
            Server.BeginAcceptTcpClient(HandleClientConnected, null);
        }

        private void HandleClientConnected(IAsyncResult result)
        {
            try
            {
                if (Server == null)
                {
                    return;
                }

                TcpClient client = Server.EndAcceptTcpClient(result);
                Clients.Add(client);
                BeginReceive(client);

                Server.BeginAcceptTcpClient(HandleClientConnected, null);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error accepting client: " + ex.Message);
            }
        }

        private void BeginReceive(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Receive error: " + ex.Message);
                }
                finally
                {
                    client.Close();
                    Clients.Remove(client);
                }
            });
        }

        public void SendMessage(string message)
        {
            if (Client == null) return;

            var stream = Client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public int GetPort()
        {
            if (Server?.LocalEndpoint is IPEndPoint endPoint)
            {
                return endPoint.Port;
            }
            return -1;
        }

        public void StopServer()
        {
            foreach (var client in Clients)
            {
                try { client.Close(); } catch { }
            }

            Clients.Clear();

            try { Server?.Stop(); } catch { }

            Server = null;
        }

        public void ConnectToServer(string ip, int port)
        {
            try
            {
                Client = new TcpClient();
                Client.Connect(IPAddress.Parse(ip), port);

                BeginReceive(Client); // berichten ontvangen van host
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect: " + ex.Message);
                throw; // doorgeven aan UI als er iets foutgaat
            }
        }
    }
}
