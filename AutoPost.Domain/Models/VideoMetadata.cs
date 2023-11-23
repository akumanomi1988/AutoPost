
namespace AutoPost.Domain.Models
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
