using AutoPost.PostGenerator.Controllers;
using AutoPost.PostGenerator.Models;
using AutoPost.PostGenerator.Recorders;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.PostGenerator
{
    // AnimationCanvas.cs
    public class AnimationCanvas
    {
        public Canvas Canvas { get; private set; }
        public List<ICanvasElement> Elements { get; private set; }
        public IVideoRecorder VideoRecorder { get; private set; }
        public IAudioRecorder AudioRecorder { get; private set; }

        public AnimationCanvas(int width, int height, Color backgroundColor)
        {
            Canvas = new Canvas(width, height, backgroundColor);
            Elements = new List<ICanvasElement>();
            // Inicializa los grabadores...
        }

        public void AddElement(ICanvasElement element)
        {
            Elements.Add(element);
        }

        public void StartAnimation()
        {
            // Implementa la lógica de animación y grabación...
        }

        // Otros métodos...
    }

    // ICanvasElement.cs
    public interface ICanvasElement
    {
        void Move(); // Mover el elemento
        void Draw(); // Dibujar el elemento
                     // Otros métodos necesarios...
    }

}
