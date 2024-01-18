using OBSWebsocketDotNet;
using System.Diagnostics;

public class OBSController
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
    public event EventHandler<OBSState>? OBSStatusChanged;

    public OBSController()
    {
        _obsWebSocket = new OBSWebsocket();
        _obsWebSocket.Connected += (s, e) => NotifyStatusChanged(OBSState.Connected);
        _obsWebSocket.Disconnected += (s, e) => NotifyStatusChanged(OBSState.Disconnected);
    }

    private void NotifyStatusChanged(OBSState newState)
    {
        OBSStatusChanged?.Invoke(this, newState);
    }

    public void Connect(string address, string password = "")
    {
        //if (!IsOBSRunning()) { NotifyStatusChanged(OBSState.NotRunning); }
        NotifyStatusChanged(IsOBSRunning() ? OBSState.Running  :OBSState.NotRunning) ;
        try
        {
            _obsWebSocket.ConnectAsync(address, password);
            // El cambio de estado se maneja en el evento Connected
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar con OBS: " + ex.Message);
        }
    }

    public void Disconnect()
    {
        _obsWebSocket.Disconnect();
        // Notificar el estado desconectado
        NotifyStatusChanged(OBSState.Disconnected);
    }

    public void StartRecording()
    {
        if (!_obsWebSocket.IsConnected) { return; }
        _obsWebSocket.StartRecord();
        NotifyStatusChanged(OBSState.Recording);
    }

    public void StopRecording()
    {
        if (_obsWebSocket.IsConnected && IsRecording)
        {
            _obsWebSocket.StopRecord();
            // Cambiar a estado Connected o Disconnected según corresponda
            NotifyStatusChanged(_obsWebSocket.IsConnected ? OBSState.Connected : OBSState.Disconnected);
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
}
