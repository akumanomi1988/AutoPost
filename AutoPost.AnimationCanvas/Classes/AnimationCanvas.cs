using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using AutoPost.AnimationCanvas.Utils;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AutoPost.AnimationCanvas.Classes
{
    public class AnimationCanvas
    {
        private readonly Canvas _canvas;
        private readonly List<ICanvasElement> _canvasElements;
        private readonly RenderWindow _window;
        private readonly MusicManager _musicManager;
        private readonly ICanvasElementFactory _factory;
        private readonly object _lock = new object();
        private bool _isAnimating = false;
        public bool IsAnimating { get { return _isAnimating; } }

        public AnimationCanvas(int width, int height, Color backgroundColor, ICanvasElementFactory factory)
        {
            ValidateCanvasSize(width, height);
            DirectoryManager.InitializeDirectories();
            _canvas = new Canvas(width, height, backgroundColor);
            _canvasElements = new List<ICanvasElement>();
            _window = WindowFactory.CreateRenderWindow(_canvas);
            _musicManager = new MusicManager();
            _factory = factory;
        }

        private void ValidateCanvasSize(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("Las dimensiones del canvas deben ser mayores que cero.");
        }

        public int CanvasElementCount() => _canvasElements.Count;

        public void AddElement()
        {
            lock (_lock)
            {
                var newElement = _factory.CreateRandomElement();
                _canvasElements.Add(newElement);
            }
        }

        public void RemoveElement()
        {
            lock (_lock)
            {
                if (_canvasElements.Count > 0)
                {
                    _canvasElements.RemoveAt(_canvasElements.Count - 1);
                }
            }
        }

        public void StartAnimation(int elementsNumber = 5, int secDuration = 60)
        {
            if (_isAnimating) return;

            InitializeAnimation(elementsNumber);
            RunAnimationLoop(secDuration);
            StopAnimation();
        }

        private void InitializeAnimation(int elementsNumber)
        {
            _musicManager.PlayBackgroundMusic();
            _window.Display();
            AddInitialElements(elementsNumber);
            _isAnimating = true;
            OnAnimationStarted();
        }

        private void AddInitialElements(int elementsNumber)
        {
            for (int i = 0; i < elementsNumber; i++)
            {
                AddElement();
            }
        }

        private void RunAnimationLoop(int secDuration)
        {
            var timeEndAnimation = DateTime.Now.AddSeconds(secDuration);
            Clock clock = new Clock();

            while (_window.IsOpen && _isAnimating && timeEndAnimation > DateTime.Now)
            {
                _window.DispatchEvents();
                _window.Clear(_canvas.BackgroundColor);
                float deltaTime = clock.Restart().AsSeconds();
                UpdateCanvasElements(deltaTime);
                _window.Display();
            }
        }

        public void StopAnimation()
        {
            if (!_isAnimating || _window == null) return;

            _isAnimating = false;
            _musicManager.StopBackgroundMusic();
            _canvasElements.Clear();
            _window.Close();
            OnAnimationStopped();
        }

        private void UpdateCanvasElements(float deltaTime)
        {
            lock (_lock)
            {
                foreach (var element in _canvasElements)
                {
                    element.Update(deltaTime);
                    CollisionManager.HandleCollisions(element, _canvasElements, _canvas);
                    _window.Draw(element);
                }
            }
        }

        protected virtual void OnAnimationStarted() => AnimationStarted?.Invoke(this, EventArgs.Empty);
        protected virtual void OnAnimationStopped() => AnimationStopped?.Invoke(this, EventArgs.Empty);

        public event EventHandler? AnimationStarted;
        public event EventHandler? AnimationStopped;
    }

    // Separar la gestión de música en una clase dedicada
    public class MusicManager
    {
        private Music _backgroundMusic;

        public MusicManager()
        {
            _backgroundMusic = new Music(DirectoryManager.MusicPath);
            _backgroundMusic.StateChanged += BackgroundMusic_StateChanged;
        }

        public void PlayBackgroundMusic()
        {
            _backgroundMusic.Play();
        }

        public void StopBackgroundMusic()
        {
            _backgroundMusic.Stop();
        }

        private void BackgroundMusic_StateChanged(SFML.Audio.SoundStatus newStatus)
        {
            Console.WriteLine("Estado de la música cambiado: " + newStatus);
            if (newStatus == SFML.Audio.SoundStatus.Stopped)
            {
                OnMusicStopped();
            }
        }

        protected virtual void OnMusicStopped() => MusicStopped?.Invoke(this, EventArgs.Empty);

        public event EventHandler? MusicStopped;
    }

    // Utilizar una clase de fábrica para crear el RenderWindow
    public static class WindowFactory
    {
        public static RenderWindow CreateRenderWindow(Canvas canvas)
        {
            var window = new RenderWindow(new VideoMode((uint)canvas.Width, (uint)canvas.Height), "AnimationBalls", Styles.None);
            window.SetFramerateLimit(120);
            window.Position = new Vector2i(0, 0);
            return window;
        }
    }

    // Manejar la creación de directorios en una clase separada
    public static class DirectoryManager
    {
        public static string MusicPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.MusicFolderPath}";
        public static string SoundsPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.SoundsFolderPath}";

        public static void InitializeDirectories()
        {
            Initializer.CreateDirectoryIfNotExist(MusicPath);
            Initializer.CreateDirectoryIfNotExist(SoundsPath);
        }
    }
}
