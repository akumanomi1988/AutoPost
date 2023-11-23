using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public interface IVideoUploader
    {
        Task<bool> UploadVideoAsync(string videoPath, VideoMetadata metadata);
    }
}
