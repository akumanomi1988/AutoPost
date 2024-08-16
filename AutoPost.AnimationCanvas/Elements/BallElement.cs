using AutoPost.AnimationCanvas.Interfaces;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System.Runtime.InteropServices;

namespace AutoPost.AnimationCanvas.Elements
{

    public class BallElement : ICanvasElement
    {
        public CircleShape Shape { get; private set; }
        public Vector2f Velocity { get; set; }
        public Sound Sound { get; set; }
        public Guid Guid { get; set; }

        public BallElement(float radius, Vector2f position, Color color, int velocity, Sound sound,Guid guid = new())
        {
            Guid = guid;
            Shape = new CircleShape(radius)
            {
                Position = position,
                FillColor = color
            };
            Velocity = new Vector2f(velocity, velocity); // Velocidad inicial
            Sound = sound;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape, states);
        }

        public void Update(float deltaTime)
        {
            // Mover el elemento
            Shape.Position += Velocity * deltaTime;
        }

    }
}
