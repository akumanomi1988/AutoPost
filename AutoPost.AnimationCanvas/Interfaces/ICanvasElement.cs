using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface ICanvasElement:Drawable
    {
        void Update(float deltaTime); 

    }

}