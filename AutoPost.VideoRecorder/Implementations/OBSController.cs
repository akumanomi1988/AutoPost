using AutoPost.VideoRecorder.Interfaces.Models;
using OBSWebsocketDotNet;
using System.Diagnostics;

public class OBSController : ISocketConnector, IVideoRecorder
{
    private OBSWebsocket _obsWebSocket;

    // Enumeración para los estados de OBS
    public enum OBSState
    {
        NotRunning,
        Running,
        Disconnected,
        Connected,
        Recording
    }

    // Evento para notificar cambios de estado
    public event EventHandler<SocketStatus.Status>? SocketStatusChanged;
    public event EventHandler<VideoRecorderStatus.Status>? VideoRecorderStatusChanged;

    public OBSController()
    {
        _obsWebSocket = new OBSWebsocket();
        _obsWebSocket.Connected += (s, e) => NotifySocketStatusChanged(SocketStatus.Status.Connected);
        _obsWebSocket.Disconnected += (s, e) => NotifySocketStatusChanged(SocketStatus.Status.Connected);
    }


    private void NotifySocketStatusChanged(SocketStatus.Status newState)
    {
        SocketStatusChanged?.Invoke(this, newState);
    }
    private void NotifyRecorderStatusChanged(VideoRecorderStatus.Status newState)
    {
        VideoRecorderStatusChanged?.Invoke(this, newState);
    }

    public void Connect(string address, string password = "")
    {

        NotifySocketStatusChanged(IsOBSRunning() ? SocketStatus.Status.Disconnected : SocketStatus.Status.ProcessNotFound);
        try
        {
            _obsWebSocket.ConnectAsync($"ws://{address}", password);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar con OBS: " + ex.Message);
        }
    }

    public void Disconnect()
    {
        _obsWebSocket.Disconnect();
        //NotifySocketStatusChanged(SocketStatus.Status.Disconnected);
    }

    public void StartRecording()
    {
        if (!_obsWebSocket.IsConnected || IsRecording) { return; }
        _obsWebSocket.StartRecord();
        NotifyRecorderStatusChanged(VideoRecorderStatus.Status.Recording);
    }

    public void StopRecording()
    {
        if (_obsWebSocket.IsConnected && IsRecording)
        {
            _obsWebSocket.StopRecord();
            NotifyRecorderStatusChanged(_obsWebSocket.IsConnected ? VideoRecorderStatus.Status.Running : VideoRecorderStatus.Status.NotRunning);
        }
    }
    private bool IsOBSRunning()
    {
        foreach (var process in Process.GetProcesses())
        {
            if (process.ProcessName.ToLower().Contains("obs64") || process.ProcessName.ToLower().Contains("obs32"))
            {
                return true;
            }
        }
        return false;
    }
    public string GetLastSavedFile()
    {
        var dir = _obsWebSocket.GetRecordDirectory();

        var directory = new DirectoryInfo(dir);
        var lastModifiedFile = directory.GetFiles()
                                        .OrderByDescending(f => f.LastWriteTime)
                                        .FirstOrDefault();

        return lastModifiedFile != null ? lastModifiedFile.FullName : "";

    }


    public bool IsConnected => _obsWebSocket.IsConnected;
    public bool IsRecording => _obsWebSocket.GetRecordStatus().IsRecording;

    bool ISocketConnector.IsConnected => throw new NotImplementedException();
}
