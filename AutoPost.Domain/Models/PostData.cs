namespace AutoPost.Domain.Models
{
    [Serializable]
    public class PostData
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string ContentPath { get; set; }
        public string Category { get; set; }
        public string Privacy { get; set; } // Ejemplo: public, private, unlisted

        public PostData(string title, string description, List<string> tags, string contentPath, string category, string privacy)
        {
            Title = title;
            Description = description;
            Tags = tags;
            ContentPath = contentPath;
            Category = category;
            Privacy = privacy;
        }
        public PostData()
        {
            Id = Guid.NewGuid(); // Genera un nuevo GUID único
            Title = "";
            Description = "";
            Tags = new List<string>(); // Inicializa con una lista vacía
            ContentPath = "";
            Category = "";
            Privacy = ""; // Opciones podrían ser: public, private, unlisted
        }
    }

}
