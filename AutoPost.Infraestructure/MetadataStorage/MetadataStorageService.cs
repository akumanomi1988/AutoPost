using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using LiteDB;

namespace AutoPost.Infraestructure.MetadataStorage
{

    using LiteDB;
    using AutoPost.Domain.Interfaces;
    using AutoPost.Domain.Models;
    using System.Threading.Tasks;

    public class MetadataStorageService : IMetadataStorageService
    {
        private readonly string _databasePath;

        public MetadataStorageService(string databasePath)
        {
            _databasePath = databasePath;
        }

        public Guid SaveMetadata(VideoMetadata metadata)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<VideoMetadata>("videos");
                collection.Upsert(metadata);
                return metadata.Id;
            }
        }

        public  VideoMetadata GetMetadata(Guid videoId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<VideoMetadata>("videos");
                return  collection.FindOne(m => m.Id == videoId);
            }
        }
        public IEnumerable<VideoMetadata> GetMetadata()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<VideoMetadata>("videos");
                return collection.FindAll().ToList();
            }
        }
        public  bool UpdateMetadata(Guid videoId, VideoMetadata updatedMetadata)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<VideoMetadata>("videos");
                var existingMetadata = collection.FindOne(m => m.Id == videoId);
                if (existingMetadata != null)
                {
                    updatedMetadata.Id = existingMetadata.Id; // Asegurarse de mantener el mismo Id
                   return collection.Update(updatedMetadata);
                }
                return false;
            }
        }

        public bool DeleteMetadata(Guid videoId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<VideoMetadata>("videos");
               return  collection.Delete(videoId);
            }
        }
    }

}


