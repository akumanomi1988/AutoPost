using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using AutoPost.AnimationCanvas.Utils;
using Microsoft.VisualBasic;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static SFML.Graphics.BlendMode;

namespace AutoPost.AnimationCanvas.Classes
{
    public class AnimationCanvas
    {
        private Canvas _Canvas;
        private List<ICanvasElement> _CanvasElements;
        private readonly IVideoRecorder _VideoRecorder;
        private readonly IAudioRecorder _AudioRecorder;
        private Music _BackgroundMusic;
        private RenderWindow? _Window;
        private volatile  bool _isAnimating = false;
        private ICanvasElementFactory _Factory;
        public static string MusicPath { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.MusicFolderPath}"; }}
        public static string SoundsPath { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Properties.Resources.SoundsFolderPath}"; } }
        
        public AnimationCanvas(int width, int height, SFML.Graphics.Color backgroundColor, IVideoRecorder videoRecorder, IAudioRecorder audioRecorder, ICanvasElementFactory factory)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("Las dimensiones del canvas deben ser mayores que cero.");

            if (videoRecorder == null) throw new ArgumentNullException(nameof(videoRecorder), "El grabador de video no puede ser nulo.");

            if (audioRecorder == null) throw new ArgumentNullException(nameof(audioRecorder), "El grabador de audio no puede ser nulo.");

            Initializer.CreateDirectoryIfNotExist(MusicPath);
            Initializer.CreateDirectoryIfNotExist(SoundsPath);
            _Canvas = new Canvas(width, height, backgroundColor);
            _CanvasElements = new List<ICanvasElement>();
            _VideoRecorder = videoRecorder;
            _AudioRecorder = audioRecorder;
            _BackgroundMusic = new Music(MusicPath  );
            _Factory = factory;
        }

        public  void StartAnimation(bool recording = false)
        {
            if (_isAnimating) { return; }


            _Window = new RenderWindow(new VideoMode((uint)_Canvas.Width, (uint)_Canvas.Height), "AnimationBalls", Styles.Close);
            _Window.SetFramerateLimit(120);
            _isAnimating = true;
            for (int i = 0; i < 5; i++)
            {
                _CanvasElements.Add(_Factory.CreateRandomElement());
            }
           
            _BackgroundMusic.Play();
            Clock clock = new Clock();

            while (_Window.IsOpen)
            {
                _Window.DispatchEvents();
                _Window.Clear(_Canvas.BackgroundColor);

                float deltaTime = clock.Restart().AsSeconds();

                foreach (var element in _CanvasElements)
                {
                    UpdateElementPosition(element, deltaTime);
                    _Window.Draw(element);

                }
                _Window.Display();
            }
        }
        private void UpdateElementPosition(ICanvasElement element, float deltaTime)
        {
            // Primero, actualiza la posición del elemento
            element.Update(deltaTime);

            BallElement ball = element as BallElement;
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
        public void StopAnimation()
        {
            if (!_isAnimating) { return; }
            _isAnimating = false;
            _CanvasElements.Clear();
        }

        private void StartRecording()
        {
            _VideoRecorder.StartRecording();
            _AudioRecorder.StartRecording();
        }

        private void StopRecording()
        {
            _VideoRecorder.StopRecording();
            _AudioRecorder.StopRecording();
        }

    }
   }
