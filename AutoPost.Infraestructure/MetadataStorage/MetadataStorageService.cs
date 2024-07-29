using AutoPost.Domain.Models;
using LiteDB;

namespace AutoPost.Infraestructure.MetadataStorage
{
    public class MetadataStorageService
    {
        private readonly string _databasePath;

        public MetadataStorageService(string databasePath)
        {
            _databasePath = databasePath;
        }

        public Guid SaveMetadata(PostData metadata)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>("videos");
            _ = collection.Upsert(metadata);
            return metadata.Id;
        }

        public PostData GetMetadata(Guid videoId)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>("videos");
            return collection.FindOne(m => m.Id == videoId);
        }
        public IEnumerable<PostData> GetMetadata()
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>("videos");
            return collection.FindAll().ToList();
        }
        public bool UpdateMetadata(Guid videoId, PostData updatedMetadata)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>("videos");
            PostData existingMetadata = collection.FindOne(m => m.Id == videoId);
            if (existingMetadata != null)
            {
                updatedMetadata.Id = existingMetadata.Id; // Asegurarse de mantener el mismo Id
                return collection.Update(updatedMetadata);
            }
            return false;
        }

        public bool DeleteMetadata(Guid videoId)
        {
            using LiteDatabase db = new(_databasePath);
            ILiteCollection<PostData> collection = db.GetCollection<PostData>("videos");
            return collection.Delete(videoId);
        }
    }

}


