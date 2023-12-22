using AutoPost.PostGenerator.Models;
using AutoPost.PostGenerator.Properties;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;

namespace AutoPost.PostGenerator.Controllers
{
    internal class BallsController
    {
        private List<SoundBuffer> SoundBuffers = new List<SoundBuffer>();
        private Random random = new Random();
        private readonly int _MinBallRadius;
        private readonly int _MaxBallRadius;
        private readonly Vector2u _ContainerSize;
        public BallsController(
            Vector2u containerSize,
            string ballSoundsPath,
            int minBallRadius = 5,
            int maxBallRadius = 30) 
        {
            //"C:\\\\Users\\\\dmozota\\\\source\\\\repos\\\\akumanomi1988\\\\AutoPost\\\\AutoPost.VideoGenerator\\\\Resources\\\\Sounds\\\\"

            var soundFiles = Directory.GetFiles(ballSoundsPath,"*ogg");
            foreach (var file in soundFiles)
            {
                SoundBuffer buffer = new SoundBuffer(file);
                SoundBuffers.Add(buffer);
            }
            _MinBallRadius = minBallRadius;
            _MaxBallRadius = maxBallRadius;
            _ContainerSize = containerSize;
        }
        public List<Ball> GetRandomBalls(int numberOfBalls = 10)
        {
            var result = new List<Ball>();
            for (int i = 1; i <= numberOfBalls; i++)
            {
                float radius = random.Next(_MinBallRadius, _MaxBallRadius);
                float x = random.Next((int)radius * 2, (int)_ContainerSize.X - ((int)radius * 2));
                float y = random.Next((int)radius * 2, (int)_ContainerSize.Y - ((int)radius * 2));
                int velocity = random.Next(500, 10000);
                bool crazyBall = random.Next(1, 10) == 5;
                int bufferIndex = random.Next(SoundBuffers.Count);
                Sound sound = new Sound(SoundBuffers[bufferIndex]);
                result.Add(new Ball(radius, new Vector2f(x, y), getRandomColor(), velocity, sound, crazyBall));
            }
            return result;
        }
        private Color getRandomColor()
        {
            byte red = (byte)random.Next(256);
            byte green = (byte)random.Next(256);
            byte blue = (byte)random.Next(256);
            return new Color(red, green, blue);

        }

    }
}
