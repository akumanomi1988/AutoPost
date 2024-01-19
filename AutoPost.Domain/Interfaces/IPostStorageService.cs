using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public interface IPostStorageService
    {
        Guid SavePost(PostData post);
        PostData GetPost(Guid postId);
        IEnumerable<PostData> GetPost();
        bool UpdatePost(Guid postId, PostData post);
        bool DeletePost(Guid postId);
    }

}
