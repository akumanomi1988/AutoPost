using AutoPost.Application.DTOs;
using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;

namespace AutoPost.Application.Services
{

    public class VideoDownloadService : IVideoDownloadService
    {
        private readonly IVideoDownloader _VideoDownloader;

        public VideoDownloadService(IVideoDownloader youTubeDownloader)
        {
            _VideoDownloader = youTubeDownloader;
        }
        async Task<VideoDownloadResultDto> IVideoDownloadService.DownloadVideoAsync(string videoUrl, string downloadPath)
        {
            string videoContent = await _VideoDownloader.DownloadVideoAsync(videoUrl, downloadPath);
            return new VideoDownloadResultDto { Path = videoContent };
        }
    }
}
