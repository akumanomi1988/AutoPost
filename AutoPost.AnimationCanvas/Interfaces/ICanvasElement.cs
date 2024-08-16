using SFML.Graphics;

namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface ICanvasElement : Drawable
    {
        Guid Guid { get; }
        void Update(float deltaTime);

    }

}