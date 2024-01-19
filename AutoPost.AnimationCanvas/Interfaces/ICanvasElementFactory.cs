namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface ICanvasElementFactory
    {
        ICanvasElement CreateRandomElement();
        ICanvasElement CreateRandomElement(string Type);
        IEnumerable<ICanvasElement> CreateRandomElements(int Quantity);
        IEnumerable<ICanvasElement> CreateRandomElements(string type, int Quantity);
    }
}
