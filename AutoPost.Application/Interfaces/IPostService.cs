using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
