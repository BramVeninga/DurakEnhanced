using System;
using WebSocketSharp;

public class WebSocketClientHandler
{
    private WebSocket ws;

    public event Action<string> OnMessageReceived;

    public void Connect(string url)
    {
        ws = new WebSocket(url);
        ws.OnMessage += (sender, e) => OnMessageReceived?.Invoke(e.Data);
        ws.Connect();
    }

    public void Send(string message)
    {
        ws?.Send(message);
    }

    public void Close()
    {
        ws?.Close();
    }
}
