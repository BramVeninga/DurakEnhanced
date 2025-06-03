using System;
using System.Windows;
using DurakTCPTest.Networking;

namespace DurakTCPTest
{
    public partial class MainWindow : Window
    {
        private TcpServer server;
        private TcpClientHandler client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartServer_Click(object sender, RoutedEventArgs e)
        {
            server = new TcpServer(5000);
            server.OnMessageReceived += OnMessageReceived;
            server.Start();
            ChatBox.Text += "Server started.\n";
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            client = new TcpClientHandler("127.0.0.1", 5000);
            client.OnMessageReceived += OnMessageReceived;
            client.Connect();
            ChatBox.Text += "Connected to server.\n";
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string msg = InputBox.Text;
            if (client != null)
            {
                client.Send(msg);
            }
            else if (server != null)
            {
                server.SendToAll(msg);
            }

            ChatBox.Text += $"Me: {msg}\n";
            InputBox.Clear();
        }

        private void OnMessageReceived(string msg)
        {
            Dispatcher.Invoke(() =>
            {
                ChatBox.Text += $"Them: {msg}\n";
            });
        }
    }
}