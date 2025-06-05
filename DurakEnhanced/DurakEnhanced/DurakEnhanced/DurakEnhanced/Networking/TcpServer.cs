using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DurakEnhanced.Networking
{
    public class TcpServer
    {
        private TcpListener listener;
        private List<StreamWriter> clients = new List<StreamWriter>();
        public event Action<string> OnMessageReceived;

        public TcpServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            new Thread(() =>
            {
                listener.Start();
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    var reader = new StreamReader(client.GetStream());
                    var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                    clients.Add(writer);

                    new Thread(() =>
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            OnMessageReceived?.Invoke(line);
                            SendToAll(line);
                        }
                    }).Start();
                }
            })
            { IsBackground = true }.Start();
        }

        public void SendToAll(string message)
        {
            foreach (var writer in clients)
            {
                writer.WriteLine(message);
            }
        }
    }
}
