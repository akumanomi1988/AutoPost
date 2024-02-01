using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using AutoPost.AnimationCanvas.Utils;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

public class BallElementFactory : ICanvasElementFactory
{
    private readonly Random _random = new();
    private readonly List<Sound> _sounds;
    private readonly int _canvasWidth;
    private readonly int _canvasHeight;

    public BallElementFactory(string soundsFolderPath, int canvasWidth, int canvasHeight)
    {
        _sounds = new List<Sound>();
        LoadSounds(soundsFolderPath);
        _canvasWidth = canvasWidth;
        _canvasHeight = canvasHeight;
    }
    private void LoadSounds(string soundsFolderPath)
    {
        foreach (string filePath in Directory.GetFiles(soundsFolderPath))
        {
            SoundBuffer buffer = new(filePath);
            _sounds.Add(new Sound(buffer));
        }
    }
    public IEnumerable<ICanvasElement> CreateRandomElements(int count)
    {
        List<ICanvasElement> elements = new();
        for (int i = 0; i < count; i++)
        {
            BallElement element;
            do
            {
                element = CreateRandomElement();
            }
            while (IsOverlapping(element, elements));

            elements.Add(element);
        }
        return elements;
    }

    private BallElement CreateRandomElement()
    {
        float radius = _random.Next(10, 30);
        Vector2f position = new(_random.Next((int)radius, _canvasWidth - (int)radius), _random.Next((int)radius, _canvasHeight - (int)radius));
        Color color = new((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
        int velocity = _random.Next(100, 400);
        Sound sound = _sounds[_random.Next(_sounds.Count)];

        return new BallElement(radius, position, color, velocity, sound);
    }

    private bool IsOverlapping(BallElement element, List<ICanvasElement> elements)
    {
        foreach (ICanvasElement other in elements)
        {
            if (other == null) { continue; }
            if (other is BallElement otherBall && CollisionManager.CheckCollision(element, otherBall))
            {
                return true;
            }
        }
        return false;
    }

    ICanvasElement ICanvasElementFactory.CreateRandomElement()
    {
        throw new NotImplementedException();
    }

    public ICanvasElement CreateRandomElement(string Type)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ICanvasElement> CreateRandomElements(string type, int Quantity)
    {
        throw new NotImplementedException();
    }
}
