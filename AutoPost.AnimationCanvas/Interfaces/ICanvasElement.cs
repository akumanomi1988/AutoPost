using SFML.Graphics;

namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface ICanvasElement : Drawable
    {
        void Update(float deltaTime);

    }

}