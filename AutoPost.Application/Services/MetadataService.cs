using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;

namespace AutoPost.Application.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly IMetadataStorageService _metadataStorageService;

        public MetadataService(IMetadataStorageService metadataStorageService)
        {
            _metadataStorageService = metadataStorageService;
        }

        public Guid SaveMetadata(VideoMetadata metadata)
        {
            return _metadataStorageService.SaveMetadata(metadata);
        }

        public VideoMetadata GetMetadata(Guid videoId)
        {
            return  _metadataStorageService.GetMetadata(videoId);
        }
        public IEnumerable<VideoMetadata> GetMetadata()
        {
            return _metadataStorageService.GetMetadata();
        }
        public bool UpdateMetadata(Guid videoId, VideoMetadata metadata)
        {
            return _metadataStorageService.UpdateMetadata(videoId, metadata);
        }

        public bool DeleteMetadata(Guid videoId)
        {
            return _metadataStorageService.DeleteMetadata(videoId);
        }
    }
}