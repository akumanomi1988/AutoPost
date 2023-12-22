using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.PostGenerator.Models
{
    public class Ball
    {
        public Color Color { get; set; }
        public CircleShape Shape;
        public Vector2f Velocity;
        public bool IsCrazyBall { get; set; }
        public Sound Sound { get; set; }
        public Ball(float radius, Vector2f position, Color color, int velocity, Sound sound, bool isCrazyBall = false)
        {
            Shape = new CircleShape(radius)
            {
                Position = position,
                FillColor = color
            };
            Velocity = new Vector2f(velocity, velocity); // Velocidad inicial
            Color = color;
            IsCrazyBall = isCrazyBall;
            Sound = sound;
        }

        public void Update(float deltaTime, int x, int y)
        {
            if (IsCrazyBall)
            {
                Random random = new Random();
                byte red = (byte)random.Next(256);
                byte green = (byte)random.Next(256);
                byte blue = (byte)random.Next(256);
                Color color = new Color(red, green, blue);
                Shape.FillColor = Color;
            }
            Shape.Position += Velocity * deltaTime;

            // Rebotar en los bordes de la ventana
            if (Shape.Position.X < 0 || Shape.Position.X + Shape.Radius * 2 > x)
                Velocity.X = -Velocity.X;
            if (Shape.Position.Y < 0 || Shape.Position.Y + Shape.Radius * 2 > y)
                Velocity.Y = -Velocity.Y;
        }
        public void HandleCollision(Ball other)
        {
            // Intercambiar las velocidades para una respuesta simple de colisión
            Vector2f tempVelocity = Velocity;
            Velocity = other.Velocity;
            other.Velocity = tempVelocity;

            if (Sound.Status != SoundStatus.Playing)
            {
                Sound.Play();
            }

        }
        public bool IsCollidingWith(Ball other)
        {
            float distance = Distance(Shape.Position, other.Shape.Position);
            return distance < Shape.Radius + other.Shape.Radius;
        }
        public static float Distance(Vector2f point1, Vector2f point2)
        {
            return (float)Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

    }
}
