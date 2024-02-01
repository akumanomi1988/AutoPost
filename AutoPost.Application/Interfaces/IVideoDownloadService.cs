using AutoPost.Application.DTOs;

namespace AutoPost.Application.Interfaces
{
    public interface IVideoDownloadService
    {
        Task<VideoDownloadResultDto> DownloadVideoAsync(string videoUrl, string downloadPath);
    }
}
