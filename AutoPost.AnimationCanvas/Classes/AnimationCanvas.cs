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
        private Canvas _Canvas;
        private List<ICanvasElement> _CanvasElements;
        private Music _BackgroundMusic;
        private RenderWindow? _Window;
        private static bool _isAnimating = false;
        public bool IsAnimating { get { return _isAnimating; } }
        private ICanvasElementFactory _Factory;
        public static string MusicPath { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.MusicFolderPath}"; } }
        public static string SoundsPath { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.SoundsFolderPath}"; } }
        private readonly object _lock = new object();
        //Events
        public delegate void AnimationEventHandler(object source, EventArgs args);
        public delegate void MusicStoppedHandler();
        public event AnimationEventHandler? AnimationStarted;
        public event AnimationEventHandler? AnimationStopped;
        public event MusicStoppedHandler? MusicStopped;

        public AnimationCanvas(int width, int height, SFML.Graphics.Color backgroundColor, ICanvasElementFactory factory)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("Las dimensiones del canvas deben ser mayores que cero.");

            Initializer.CreateDirectoryIfNotExist(MusicPath);
            Initializer.CreateDirectoryIfNotExist(SoundsPath);

            _Canvas = new Canvas(width, height, backgroundColor);
            _CanvasElements = new List<ICanvasElement>();
            _BackgroundMusic = new Music(MusicPath);
            _BackgroundMusic.StateChanged += BackgroundMusic_StateChanged;
            _Factory = factory;

        }
        protected virtual void OnAnimationStopped()
        {
            if (AnimationStopped != null)
            {
                // Invocar el evento, pasando this como fuente y EventArgs vacío
                AnimationStopped(this, EventArgs.Empty);
            }
        }
        protected virtual void OnAnimationStarted()
        {
            // Verificar si hay suscriptores al evento
            if (AnimationStarted != null)
            {
                // Invocar el evento, pasando this como fuente y EventArgs vacío, o tus propios argumentos si necesitas pasar información
                AnimationStarted(this, EventArgs.Empty);
            }
        }
        public int CanvasElementCount()
        {
            return _CanvasElements.Count;
        }
        public void AddBall()
        {
            lock (_lock)
            {
                var newElement = _Factory.CreateRandomElement();
                _CanvasElements.Add(newElement);
            }
        }

        public void RemoveBall()
        {
            lock (_lock)
            {
                if (_CanvasElements.Count > 0)
                {
                    _CanvasElements.RemoveAt(_CanvasElements.Count - 1);
                }
            }
        }

        private void BackgroundMusic_StateChanged(SFML.Audio.SoundStatus newStatus)
        {
            Console.WriteLine("Estado de la música cambiado: " + newStatus);
            if (newStatus == SFML.Audio.SoundStatus.Stopped)
            {
                OnMusicStopped();
            }
        }
        protected virtual void OnMusicStopped()
        {
            MusicStopped?.Invoke();
        }

        #region Animation

        public void StartAnimation(int BallsNumber = 5, int SecDuration = 60)
        {
            if (_isAnimating) { return; }
            _BackgroundMusic = new Music(MusicPath);
            var timeEndAnimation = DateTime.Now.AddSeconds(SecDuration);
            _Window = new RenderWindow(new VideoMode((uint)_Canvas.Width, (uint)_Canvas.Height), "AnimationBalls", Styles.None);
            _Window.SetFramerateLimit(120);
            _Window.Position = new Vector2i(0, 0);
            _isAnimating = true;

            for (int i = 0; i < BallsNumber; i++)
            {
                _CanvasElements.Add(_Factory.CreateRandomElement());
            }

            _BackgroundMusic.Play();
            Clock clock = new Clock();

            _Window.Display();
            OnAnimationStarted();
            while (_Window.IsOpen && _isAnimating && timeEndAnimation > DateTime.Now)
            {
                _Window.DispatchEvents();
                _Window.Clear(_Canvas.BackgroundColor);

                float deltaTime = clock.Restart().AsSeconds();

                lock (_lock)
                {
                    foreach (var element in _CanvasElements)
                    {
                        UpdateElementPosition(element, deltaTime);
                        _Window.Draw(element);
                    }
                }
                _Window.Display();
            }
            StopAnimation();
        }
        public void StopAnimation()
        {
            if (!_isAnimating) { return; }
            if (_Window == null) { return; }
            _isAnimating = false;
            _BackgroundMusic.Stop();
            _CanvasElements.Clear();
            _Window.Close();
            OnAnimationStopped();

        }

        private void UpdateElementPosition(ICanvasElement element, float deltaTime)
        {
            // Primero, actualiza la posición del elemento
            element.Update(deltaTime);

            BallElement? ball = element as BallElement;
            if (ball != null)
            {
                // Colisión con los bordes horizontales del canvas
                if (ball.Shape.Position.X < 0)
                {
                    ball.Velocity = new Vector2f(-ball.Velocity.X, ball.Velocity.Y);
                    ball.Shape.Position = new Vector2f(0, ball.Shape.Position.Y);
                }
                else if (ball.Shape.Position.X + ball.Shape.Radius * 2 > _Canvas.Width)
                {
                    ball.Velocity = new Vector2f(-ball.Velocity.X, ball.Velocity.Y);
                    ball.Shape.Position = new Vector2f(_Canvas.Width - ball.Shape.Radius * 2, ball.Shape.Position.Y);
                }

                // Colisión con los bordes verticales del canvas
                if (ball.Shape.Position.Y < 0)
                {
                    ball.Velocity = new Vector2f(ball.Velocity.X, -ball.Velocity.Y);
                    ball.Shape.Position = new Vector2f(ball.Shape.Position.X, 0);
                }
                else if (ball.Shape.Position.Y + ball.Shape.Radius * 2 > _Canvas.Height)
                {
                    ball.Velocity = new Vector2f(ball.Velocity.X, -ball.Velocity.Y);
                    ball.Shape.Position = new Vector2f(ball.Shape.Position.X, _Canvas.Height - ball.Shape.Radius * 2);
                }

                // Verifica colisiones con otros elementos
                // Verifica colisiones con otros elementos
                foreach (var otherElement in _CanvasElements)
                {
                    if (otherElement != element && otherElement is BallElement otherBall && CollisionDetector.CheckCollision(ball, otherBall))
                    {
                        // Calcula la normal de la colisión
                        Vector2f delta = ball.Shape.Position - otherBall.Shape.Position;
                        Vector2f collisionNormal = Normalize(delta);

                        // Manejar la colisión
                        ball.Sound.Play();
                        ball.Velocity = Reflect(ball.Velocity, collisionNormal);
                        otherBall.Velocity = Reflect(otherBall.Velocity, -collisionNormal);

                        // Ajustar la posición para evitar superposición
                        float overlap = (ball.Shape.Radius + otherBall.Shape.Radius) - Distance(ball.Shape.Position, otherBall.Shape.Position) + 1.0f;
                        collisionNormal = Normalize(collisionNormal); // Normalizar de nuevo por si acaso
                        ball.Shape.Position += collisionNormal * overlap / 2f;
                        otherBall.Shape.Position -= collisionNormal * overlap / 2f;
                    }
                }

            }
        }

        private Vector2f Normalize(Vector2f vector)
        {
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (length != 0)
            {
                return new Vector2f(vector.X / length, vector.Y / length);
            }
            return vector;
        }

        private Vector2f Reflect(Vector2f velocity, Vector2f normal)
        {
            return velocity - 2f * DotProduct(velocity, normal) * normal;
        }

        private float DotProduct(Vector2f a, Vector2f b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        private float Distance(Vector2f a, Vector2f b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        #endregion
        public int MusicDuration()
        {
            return _BackgroundMusic.MusicDuration();
        }
    }
}
