using AutoPost.Domain.Models;

namespace AutoPost.Application.Interfaces
{
    public interface IPostService
    {
        Guid SavePost(PostData post);
        IEnumerable<PostData> GetPost();
        PostData GetPost(Guid postId);
        bool UpdatePost(Guid postId, PostData post);
        bool DeletePost(Guid postId);
    }

}
