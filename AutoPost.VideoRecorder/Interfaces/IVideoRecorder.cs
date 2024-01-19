
using AutoPost.VideoRecorder.Interfaces.Models;

public interface IVideoRecorder
{
    bool IsRecording { get; }

    event EventHandler<VideoRecorderStatus.Status>? VideoRecorderStatusChanged;

    string GetLastSavedFile();
    void StartRecording();
    void StopRecording();
}
