using AutoPost.VideoGenerator.Properties;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoPost.VideoGenerator
{
    public class Screen
    {
        public Vector2u Size { get; set; }
        public SFML.Graphics.Color BackgroundColor { get; set; }
        public List<Ball> Balls { get; private set; }
        public string SoundsPath { get; set; }
        public string MusicPath { get; set; }

        public Screen(Vector2u size, SFML.Graphics.Color backgroundColor, string soundsPath, string musicPath)
        {
            Size = size;
            BackgroundColor = backgroundColor;
            SoundsPath = soundsPath;
            Balls = new List<Ball>();
            MusicPath = musicPath;
        }
        public void Random()
        {
            Random random = new Random();
            var soundFiles = Directory.GetFiles("C:\\\\Users\\\\dmozota\\\\source\\\\repos\\\\akumanomi1988\\\\AutoPost\\\\AutoPost.VideoGenerator\\\\Resources\\\\Sounds\\\\");
            List<SoundBuffer> SoundBuffers = new List<SoundBuffer>();

            foreach (var file in soundFiles)
            {
                SoundBuffer buffer = new SoundBuffer(file);
                SoundBuffers.Add(buffer);
            }
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                float radius = random.Next(5, 30);
                float x = random.Next((int)radius * 2, (int)Size.X - ((int)radius * 2));
                float y = random.Next((int)radius * 2, (int)Size.Y - ((int)radius * 2));
                byte red = (byte)random.Next(256);
                byte green = (byte)random.Next(256);
                byte blue = (byte)random.Next(256);
                int velocity = random.Next(500, 10000);
                SFML.Graphics.Color color = new SFML.Graphics.Color(red, green, blue);
                bool crazyBall = random.Next(1,10) == 5;


                int bufferIndex = random.Next(SoundBuffers.Count);
                Sound sound = new Sound(SoundBuffers[bufferIndex]);

                Balls.Add(new Ball( radius,new Vector2f(x,y), color, velocity, sound, crazyBall));
            }
        }
        public void Run()
        {
            RenderWindow window = new RenderWindow(new VideoMode(Size.X, Size.Y), "Bouncing balls",Styles.Close);
            window.SetActive();
            window.SetFramerateLimit(120);
            Clock clock = new Clock();
            float deltaTime = clock.Restart().AsSeconds();

            while (window.IsOpen && clock.ElapsedTime.AsSeconds() < 120)
            {
                window.DispatchEvents();
                window.Clear(BackgroundColor);
                for (int i = 0; i < Balls.Count; i++)
                {
                    for (int j = i + 1; j < Balls.Count; j++)
                    {
                        if (Balls[i].IsCollidingWith(Balls[j]))
                        {
                            Balls[i].HandleCollision(Balls[j]);
                        }
                    }
                }
                foreach (var ball in Balls)
                {
                    ball.Update(deltaTime, (int)Size.X, (int)Size.Y);
                    window.Draw(ball.Shape);
                }
                window.Display();
            }

        }
        public void ExportToVideo(string videoPath)
        {
            // Aquí implementarías la lógica para exportar la animación a video.
            // Esta función puede ser bastante compleja ya que implica capturar cada frame de la animación
            // y luego usar una biblioteca como SharpAvi para escribir esos frames en un archivo de video.
        }
    }
}
