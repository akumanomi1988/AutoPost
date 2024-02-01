using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Entities
{

    public class Post
    {
        public PostData PostData { get; set; }
        public string VideoPath { get; set; }

        public Post(PostData postData, string videoPath)
        {
            PostData = postData;
            VideoPath = videoPath;
        }

        public Post()
        {
            PostData = new PostData();
            VideoPath = "";
        }
    }
}
