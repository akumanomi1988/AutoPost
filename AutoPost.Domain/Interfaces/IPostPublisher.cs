using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public interface IPostPublisher
    {
        Task<int> UploadPostAsync(PostData post);
    }
}
