using AutoPost.AnimationCanvas.Classes;
using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Factories
{
    public class CanvasElementFactory : ICanvasElementFactory
    {
        private Random _random = new Random();
        private List<Sound> _sounds;

        public CanvasElementFactory(string soundsFolderPath)
        {
            _sounds = new List<Sound>();
            LoadSounds(soundsFolderPath);
        }

        private void LoadSounds(string soundsFolderPath)
        {
            foreach (var filePath in Directory.GetFiles(soundsFolderPath))
            {
                SoundBuffer buffer = new SoundBuffer(filePath);
                _sounds.Add(new Sound(buffer));
            }
        }
        public ICanvasElement CreateRandomElement()
        {
            float radius = _random.Next(10, 30);
            Vector2f position = new Vector2f(_random.Next(0, 800), _random.Next(0, 600));
            Color color = new Color((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
            int velocity = _random.Next(100, 300);

            Sound sound = _sounds[_random.Next(_sounds.Count)];

            return (ICanvasElement)new BallElement(radius, position, color, velocity, sound);
        }
        public ICanvasElement CreateRandomElement(string Type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICanvasElement> CreateRandomElements(int Quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICanvasElement> CreateRandomElements(string type, int Quantity)
        {
            throw new NotImplementedException();
        }
    }
}
