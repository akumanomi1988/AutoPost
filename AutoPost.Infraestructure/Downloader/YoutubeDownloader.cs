using AutoPost.Domain.Interfaces;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace AutoPost.Infraestructure.Downloader
{
    // En Infrastructure/Services
    public class YouTubeDownloader : IVideoDownloader
    {
        public async Task<string> DownloadVideoAsync(string videoUrl, string downloadPath)
        {
            var youtube = new YoutubeClient();
            var videoId = ExtractIdFromUrl(videoUrl);
            var video = await youtube.Videos.GetAsync(videoId);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            if (streamInfo == null) { return "Error"; }
            var filePath = $"{video.Title}.{streamInfo.Container}";
            filePath = Path.GetInvalidFileNameChars().Aggregate(filePath, (current, c) => current.Replace(c, '-'));
            filePath = $"{downloadPath}\\{filePath}";
            if (File.Exists(filePath)) return filePath;
            await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);
            return filePath;
        }
        private static string ExtractIdFromUrl(string url)
        {
            var initialIndex = url.LastIndexOf("=") + 1;
            return url.Substring(initialIndex);
        }
    }
}
