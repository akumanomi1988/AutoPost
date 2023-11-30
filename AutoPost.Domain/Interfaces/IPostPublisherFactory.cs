namespace AutoPost.Domain.Interfaces
{
    public interface IPostPublisherFactory
    {
        IPostPublisher CreatePublisher(string platform);
    }
}
