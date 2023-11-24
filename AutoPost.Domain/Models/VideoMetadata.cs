
using System.Diagnostics;

namespace AutoPost.Domain.Models
{
    public class VideoMetadata
    {
        public Guid Id { get; set; }
        public EPlatforms Platform { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag> { };
        public string CategoryId { get; set; }
        public EPrivacidad Privacy { get; set; }
        public string VideoPath { get; set; }
        public enum EPrivacidad
        {
            PRIVATE,
            PUBLIC,
            UNLISTED
        }
        public enum EPlatforms
        {
            Youtube,
            Instagram,
            TikTok
        }
        
    }
    public class Tag
    {
        public required string Text { get; set; }
    }


}
