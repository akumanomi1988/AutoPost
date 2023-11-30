
using AutoPost.Domain.Models;

namespace AutoPost.Application.Interfaces
{
    public interface IPublishService
    {
        Task<Post> PublishAsync(Post post);
    }


}
