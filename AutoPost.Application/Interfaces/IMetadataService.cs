using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Application.Interfaces
{
    public interface IMetadataService
    {
        Guid SaveMetadata(VideoMetadata metadata);
        IEnumerable<VideoMetadata> GetMetadata();
        VideoMetadata GetMetadata(Guid videoId);
        bool UpdateMetadata(Guid videoId, VideoMetadata metadata);
        bool DeleteMetadata(Guid videoId);
    }

}
