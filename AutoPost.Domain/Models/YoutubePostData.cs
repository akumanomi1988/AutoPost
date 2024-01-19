namespace AutoPost.Domain.Models
{
    public class YoutubePostData : PostData
    {
        public string PlaylistId { get; set; } // ID de la lista de reproducción
        public bool EnableComments { get; set; } // Habilitar o deshabilitar comentarios
                                                 // Otros campos específicos de YouTube...

        public YoutubePostData(string title, string description, List<string> tags, string contentPath, string category, string privacy, string playlistId, bool enableComments)
            : base(title, description, tags, contentPath, category, privacy)
        {
            PlaylistId = playlistId;
            EnableComments = enableComments;
        }
    }

}
