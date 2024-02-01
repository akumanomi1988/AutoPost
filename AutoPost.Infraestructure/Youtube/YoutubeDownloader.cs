using AutoPost.Domain.Interfaces;

namespace AutoPost.Infraestructure.Youtube
{
    // En Infrastructure/Services
    public class YouTubeDownloader : IYouTubeDownloader
    {
        public async Task<string> DownloadVideoAsync(string videoUrl, string downloadPath)
        {
            await Task.Delay(1);
            return "";
        }
    }
}
