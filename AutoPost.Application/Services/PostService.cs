using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;

namespace AutoPost.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostStorageService _PostStorageService;

        public PostService(IPostStorageService PostStorageService)
        {
            _PostStorageService = PostStorageService;
        }

        public Guid SavePost(PostData Post)
        {
            return _PostStorageService.SavePost(Post);
        }

        public PostData GetPost(Guid PostId)
        {
            return  _PostStorageService.GetPost(PostId);
        }
        public IEnumerable<PostData> GetPost()
        {
            return _PostStorageService.GetPost();
        }
        public bool UpdatePost(Guid PostId, PostData post)
        {
            return _PostStorageService.UpdatePost(PostId, post);
        }

        public bool DeletePost(Guid PostId)
        {
            return _PostStorageService.DeletePost(PostId);
        }
    }
}