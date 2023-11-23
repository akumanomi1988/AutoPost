using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.DTOs
{
    public class VideoMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public string CategoryId { get; set; }
        public EPrivacidad Privacidad { get; set; }
        public enum EPrivacidad
        {
            PRIVATED,
            PUBLIC,
            UNLISTED
        }
    }

}
