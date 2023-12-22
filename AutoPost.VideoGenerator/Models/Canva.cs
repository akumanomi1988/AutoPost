using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.PostGenerator.Models
{
    public class Canvas
    {
        public int Width { get; }
        public int Height { get; }
        public Color BackgroundColor { get; }

        public Canvas(int width, int height, Color backgroundColor)
        {
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
        }

        public void Draw(ICanvasElement element)
        {
            // Implementar el dibujo del elemento en el canvas
        }
    }

}
