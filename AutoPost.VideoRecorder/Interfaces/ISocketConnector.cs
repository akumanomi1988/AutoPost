
using AutoPost.VideoRecorder.Interfaces.Models;

public interface ISocketConnector
{
    bool IsConnected { get; }

    event EventHandler<SocketStatus.Status>? SocketStatusChanged;

    void Connect(string address, string password = "");
    void Disconnect();

}