namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface ICanvasElementFactory
    {
        ICanvasElement CreateCustomElement(float radius, float positionX, float positionY, byte colorR, byte colorG, byte colorB, int velocity, int soundIndex);
        ICanvasElement CreateRandomElement();
        ICanvasElement CreateRandomElement(string Type);
        IEnumerable<ICanvasElement> CreateRandomElements(int Quantity);
        IEnumerable<ICanvasElement> CreateRandomElements(string type, int Quantity);

    }
}
