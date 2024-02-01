using SFML.Audio;

namespace AutoPost.AnimationCanvas.Classes
{
    public class SoundEffect
    {
        private readonly SoundBuffer _buffer;
        private readonly Sound _sound;

        public SoundEffect(string filePath)
        {
            _buffer = new SoundBuffer(filePath);
            _sound = new Sound(_buffer);
        }

        public void Play()
        {
            _sound.Play();
        }
    }

}
