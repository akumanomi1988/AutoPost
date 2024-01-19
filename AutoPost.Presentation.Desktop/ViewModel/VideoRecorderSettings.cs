namespace AutoPost.Presentation.Desktop.ViewModel
{
    public class VideoRecorderSettings
    {
        public string RecorderIP { get; set; }
        public int Port { get; set; }
        public string Password { get; set; } = "";
        public int DurationRecorderSec { get; set; }

        public VideoRecorderSettings(string recorderIP, int port, int durationRecorderSec)
        {
            RecorderIP = recorderIP;
            Port = port;
            DurationRecorderSec = durationRecorderSec;
        }

        public VideoRecorderSettings(string recorderIP, int port, string password, int durationRecorderSec)
        {
            RecorderIP = recorderIP;
            Port = port;
            Password = password;
            DurationRecorderSec = durationRecorderSec;
        }
        public VideoRecorderSettings()
        {
            RecorderIP = "";
            Port = 0;
            Password = "";
            DurationRecorderSec = 0;
        }
    }


}
