using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
