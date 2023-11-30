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
        Guid SavePost(Post post);
        Post GetPost(Guid postId);
        IEnumerable<Post> GetPost();
        bool UpdatePost(Guid postId, Post post);
        bool DeletePost(Guid postId);
    }

}
