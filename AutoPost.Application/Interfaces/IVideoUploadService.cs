
using AutoPost.Domain.Models;

namespace AutoPost.Application.Interfaces
{
    public interface IVideoUploadService
    {
        Task UploadVideoAsync(string platform, VideoMetadata metadata);
    }


}
