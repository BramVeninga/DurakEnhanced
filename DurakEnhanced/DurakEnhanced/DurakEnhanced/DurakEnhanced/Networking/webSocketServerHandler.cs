using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class WebSocketServerHandler : WebSocketBehavior
{
    public static event Action<string> OnServerMessageReceived;

    protected override void OnMessage(MessageEventArgs e)
    {
        OnServerMessageReceived?.Invoke(e.Data);
    }

    public static WebSocketServer Start(int port)
    {
        var wssv = new WebSocketServer(port);
        wssv.AddWebSocketService<WebSocketServerHandler>("/game");
        wssv.Start();
        return wssv;
    }
}
