using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public interface IPostPublisher
    {
        Task<int> UploadVideoAsync(Post post);
    }
}
