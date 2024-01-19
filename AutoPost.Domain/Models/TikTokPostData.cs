namespace AutoPost.Domain.Models
{
    public class TikTokPostData : PostData
    {
        public bool AllowDuet { get; set; } // Permitir o no duetos
                                            // Otros campos específicos de TikTok...

        public TikTokPostData(string title, string description, List<string> tags, string contentPath, string category, string privacy, bool allowDuet)
            : base(title, description, tags, contentPath, category, privacy)
        {
            AllowDuet = allowDuet;
        }
    }

}
