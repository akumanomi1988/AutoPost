namespace AutoPost.Domain.Models
{
    public class InstagramPostData : PostData
    {
        public bool IsStory { get; set; } // Determina si es una historia o una publicación en el feed
                                          // Otros campos específicos de Instagram...

        public InstagramPostData(string title, string description, List<string> tags, string contentPath, string category, string privacy, bool isStory)
            : base(title, description, tags, contentPath, category, privacy)
        {
            IsStory = isStory;
        }
    }

}
