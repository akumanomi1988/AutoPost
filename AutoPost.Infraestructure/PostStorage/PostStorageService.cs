using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using LiteDB;

namespace AutoPost.Infraestructure.PostStorage
{

    using LiteDB;
    using AutoPost.Domain.Interfaces;
    using AutoPost.Domain.Models;
    using System.Threading.Tasks;

    public class PostStorageService : IPostStorageService
    {
        const string Table = "Posts";
        private readonly string _databasePath;
        

        public PostStorageService(string databasePath)
        {
            _databasePath = databasePath;
        }

        public Guid SavePost(Post post)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<Post>(Table);
                return collection.Insert(post);
            }
        }

        public Post GetPost(Guid postId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<Post>(Table);
                return  collection.FindOne(m => m.Id == postId);
            }
        }
        public IEnumerable<Post> GetPost()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<Post>(Table);
                return collection.FindAll().ToList();
            }
        }
        public  bool UpdatePost(Guid postId, Post updatedPost)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<Post>(Table);
                var existingPost = collection.FindOne(m => m.Id == postId);
                if (existingPost != null)
                {
                    updatedPost.Id = existingPost.Id; // Asegurarse de mantener el mismo Id
                   return collection.Update(updatedPost);
                }
                return false;
            }
        }

        public bool DeletePost(Guid videoId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<Post>(Table);
               return  collection.Delete(videoId);
            }
        }
    }

}


