using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public interface IPostPublisher
    {
        Task<bool> UploadVideoAsync(Post post);
    }
}
