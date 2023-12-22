using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
namespace AutoPost.AnimationCanvas.Classes
{
    public class Music
    {
        private SFML.Audio.Music _music;

        public Music(string filePath)
        {
            var a = Directory.EnumerateFiles(filePath);
            if (a.Count() == 0)
            {
                throw new Exception("No hay archivo de musica en la carpeta");
            }
            _music = new SFML.Audio.Music(a.First());
        }

        public void Play()
        {
            _music.Play();
        }
    }

}
