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
        Guid SavePost(Post post);
        IEnumerable<Post> GetPost();
        Post GetPost(Guid postId);
        bool UpdatePost(Guid postId, Post post);
        bool DeletePost(Guid postId);
    }

}
