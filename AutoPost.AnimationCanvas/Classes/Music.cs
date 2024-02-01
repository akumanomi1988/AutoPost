using SFML.Audio;

namespace AutoPost.AnimationCanvas.Classes
{
    public class Music
    {
        private readonly SFML.Audio.Music _music;
        private SFML.Audio.SoundStatus _lastStatus;

        // Delegado y evento para el cambio de estado
        public delegate void StateChangedHandler(SFML.Audio.SoundStatus newStatus);
        public event StateChangedHandler? StateChanged;

        public Music(string filePath)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(filePath, "*.ogg"); // Asumiendo que son archivos .ogg
            if (!files.Any())
            {
                throw new Exception("No hay archivo de música en la carpeta");
            }
            Random rnd = new();
            _music = new SFML.Audio.Music(files.ElementAt(rnd.Next(files.Count())));
            _lastStatus = SFML.Audio.SoundStatus.Stopped;
        }

        public void Play()
        {
            _music.Play();
            MonitorStatus();
        }

        public void Stop()
        {
            if (_music.Status == SoundStatus.Playing)
            {
                _music.Stop();
            }
        }

        private void MonitorStatus()
        {
            _ = Task.Run(() =>
            {
                while (_music.Status != SFML.Audio.SoundStatus.Stopped)
                {
                    if (_music.Status != _lastStatus)
                    {
                        _lastStatus = _music.Status;
                        OnStateChanged(_lastStatus);
                    }
                    System.Threading.Thread.Sleep(100); // Espera para reducir la carga del CPU
                }
            });
        }

        protected virtual void OnStateChanged(SFML.Audio.SoundStatus newStatus)
        {
            StateChanged?.Invoke(newStatus);
        }
        public int MusicDuration()
        {
            return (int)_music.Duration.AsSeconds();
        }
    }
}
