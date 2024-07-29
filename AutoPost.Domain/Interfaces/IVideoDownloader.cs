namespace AutoPost.Domain.Interfaces
{
    public interface IVideoDownloader
    {
        Task<string> DownloadVideoAsync(string videoUrl, string downloadPath);
    }
}
