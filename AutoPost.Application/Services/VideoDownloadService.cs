using AutoPost.Application.DTOs;
using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;

namespace AutoPost.Application.Services
{

    public class VideoDownloadService : IVideoDownloadService
    {
        private readonly IYouTubeDownloader _youTubeDownloader;

        public VideoDownloadService(IYouTubeDownloader youTubeDownloader)
        {
            _youTubeDownloader = youTubeDownloader;
        }
        async Task<VideoDownloadResultDto> IVideoDownloadService.DownloadVideoAsync(string videoUrl, string downloadPath)
        {
            string videoContent = await _youTubeDownloader.DownloadVideoAsync(videoUrl, downloadPath);
            return new VideoDownloadResultDto { URL = videoContent };
        }
    }
}
