namespace AutoPost.Presentation.Desktop.ViewModel
{

    public class PostSettings
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string TagsText { get { return $"#{string.Join(";#", Tags)}".Replace(" ", ""); } set { Tags = value.Replace("#", "").Split(";").ToList(); } }
        public string ContentPath { get; set; }
        public string Category { get; set; }
        public string Privacy { get; set; } // Ejemplo: public, private, unlisted

        public PostSettings(string title, string description, List<string> tags, string contentPath, string category, string privacy)
        {
            Title = title;
            Description = description;
            Tags = tags;
            ContentPath = contentPath;
            Category = category;
            Privacy = privacy;
        }
        public PostSettings()
        {
            Title = "";
            Description = "";
            Tags = new List<string>(); // Inicializa con una lista vacía
            ContentPath = "";
            Category = "";
            Privacy = ""; // Opciones podrían ser: public, private, unlisted
        }

    }
}
