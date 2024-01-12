
using AutoPost.Domain.Models;

namespace AutoPost.Application.Interfaces
{
    public interface IPublishService
    {
        Task<PostData> PublishAsync(PostData post);
    }


}
