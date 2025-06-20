using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DurakEnhanced.Networking
{
    public class TcpClientHandler
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        public event Action<string> OnMessageReceived;

        private string host;
        private int port;

        public TcpClientHandler(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Connect()
        {
            client = new TcpClient(host, port);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };

            new Thread(() =>
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    OnMessageReceived?.Invoke(line);
                }
            })
            { IsBackground = true }.Start();
        }

        public void Send(string message)
        {
            writer?.WriteLine(message);
        }
    }
}
