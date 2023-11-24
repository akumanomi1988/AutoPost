using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Interfaces
{
    public interface IMetadataStorageService
    {
        Guid SaveMetadata(VideoMetadata metadata);
        VideoMetadata GetMetadata(Guid videoId);
        IEnumerable<VideoMetadata> GetMetadata();
        bool UpdateMetadata(Guid videoId, VideoMetadata metadata);
        bool DeleteMetadata(Guid videoId);
    }

}
