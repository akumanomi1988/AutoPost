using AutoPost.AnimationCanvas.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Classes
{
    internal class Canvas
    {
        public int Width { get; }
        public int Height { get; }
        public SFML.Graphics.Color BackgroundColor { get; }

        public Canvas(int width, int height, SFML.Graphics.Color backgroundColor)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Las dimensiones del canvas deben ser mayores que cero.");
            }

            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
        }
    }

   

}
