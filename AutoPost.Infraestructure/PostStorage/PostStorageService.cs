using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using LiteDB;

namespace AutoPost.Infraestructure.PostStorage
{
    public class PostStorageService : IPostStorageService
    {
        private const string Table = "Posts";
        private readonly string _databasePath;


        public PostStorageService(string databasePath)
        {
            _databasePath = databasePath;
        }

        public Guid SavePost(PostData post)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>(Table);
            return collection.Insert(post);
        }

        public PostData GetPost(Guid postId)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>(Table);
            return collection.FindOne(m => m.Id == postId);
        }
        public IEnumerable<PostData> GetPost()
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>(Table);
            return collection.FindAll().ToList();
        }
        public bool UpdatePost(Guid postId, PostData updatedPost)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>(Table);
            PostData existingPost = collection.FindOne(m => m.Id == postId);
            if (existingPost != null)
            {
                updatedPost.Id = existingPost.Id; // Asegurarse de mantener el mismo Id
                return collection.Update(updatedPost);
            }
            return false;
        }

        public bool DeletePost(Guid videoId)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>(Table);
            return collection.Delete(videoId);
        }
    }

}


