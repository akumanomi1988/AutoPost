using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace AutoPost.AnimationCanvas.Factories
{
    public class CanvasElementFactory : ICanvasElementFactory
    {
        private readonly Random _random = new();
        private readonly List<Sound> _sounds;

        public CanvasElementFactory(string soundsFolderPath)
        {
            _sounds = new List<Sound>();
            LoadSounds(soundsFolderPath);
        }

        private void LoadSounds(string soundsFolderPath)
        {
            foreach (string filePath in Directory.GetFiles(soundsFolderPath))
            {
                SoundBuffer buffer = new(filePath);
                _sounds.Add(new Sound(buffer));
            }
        }
        public ICanvasElement CreateCustomElement(float radius, float positionX, float positionY, byte colorR, byte colorG, byte colorB, int velocity, int soundIndex)
        {
            if (soundIndex >= _sounds.Count)
            {
                soundIndex = _sounds.Count - 1;
            }
            Vector2f position = new Vector2f(positionX, positionY);
            return CreateCustomElement(radius, position, colorR, colorG, colorB, velocity, soundIndex);
        }

        public ICanvasElement CreateCustomElement(float radius, Vector2f position, byte colorR, byte colorG, byte colorB, int velocity, int soundIndex)
        {
            // Asegurarse de que el soundIndex no supere el índice máximo
            if (soundIndex >= _sounds.Count)
            {
                soundIndex = _sounds.Count - 1; // Asignar el máximo índice permitido
            }
            SFML.Graphics.Color color = new(colorR, colorG, colorB);
            Sound sound = _sounds[soundIndex];

            // Crear y devolver el elemento
            return  CreateCustomElement(radius, position, color, velocity, soundIndex);
        }
        public ICanvasElement CreateCustomElement(float radius, float positionX, float positionY, SFML.Graphics.Color color, int velocity, int soundIndex)
        {
            // Asegurarse de que el soundIndex no supere el índice máximo
            if (soundIndex >= _sounds.Count)
            {
                soundIndex = _sounds.Count - 1; // Asignar el máximo índice permitido
            }

            // Crear las estructuras de datos necesarias
            Vector2f position = new Vector2f(positionX, positionY);
            Sound sound = _sounds[soundIndex];

            // Crear y devolver el elemento
            return new BallElement(radius, position, color, velocity, sound);
        }
        public ICanvasElement CreateCustomElement(float radius, Vector2f position, SFML.Graphics.Color color, int velocity, int soundIndex)
        {
            // Asegurarse de que el soundIndex no supere el índice máximo
            if (soundIndex >= _sounds.Count)
            {
                soundIndex = _sounds.Count - 1; // Asignar el máximo índice permitido
            }
            Sound sound = _sounds[soundIndex];

            // Crear y devolver el elemento
            return new BallElement(radius, position, color, velocity, sound);
        }

        public ICanvasElement CreateRandomElement()
        {
            float radius = _random.Next(10, 30);
            Vector2f position = new(_random.Next(0, 800), _random.Next(0, 600));
            SFML.Graphics.Color color = new((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
            int velocity = _random.Next(100, 300);

            Sound sound = _sounds[_random.Next(_sounds.Count)];

            return new BallElement(radius, position, color, velocity, sound);
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
