namespace AutoPost.Domain.Interfaces
{
    public interface IYouTubeDownloader
    {
        Task<string> DownloadVideoAsync(string videoUrl, string downloadPath);
    }
}
