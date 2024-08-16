using AutoPost.AnimationCanvas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Helpers
{
    internal class BallsHelper
    {
        public static ICanvasElement GetStartingBall(ICanvasElementFactory factory,int soundCount)
        {
            Random _random = new();
            Color color = ColorsHelper.GetColorByName("White");
            return factory.CreateCustomElement(1, _random.Next(100, 400), _random.Next(100, 400), color.R, color.G, color.B, 1, _random.Next(1, soundCount));
        }
    }
}
