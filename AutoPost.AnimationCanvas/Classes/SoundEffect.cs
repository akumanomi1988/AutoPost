using SFML.Audio;

namespace AutoPost.AnimationCanvas.Classes
{
    public class SoundEffect
    {
        private SoundBuffer _buffer;
        private Sound _sound;

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
