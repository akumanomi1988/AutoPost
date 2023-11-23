namespace AutoPost.Domain.Interfaces
{
    public interface IVideoUploaderFactory
    {
        IVideoUploader CreateUploader(string platform);
    }
}
