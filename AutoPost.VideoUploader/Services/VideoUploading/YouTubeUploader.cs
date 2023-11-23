using AutoPost.VideoUploader.DTOs;
using AutoPost.VideoUploader.Interfaces;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace AutoPost.VideoUploader.Services.VideoUploading
{


    public class YouTubeUploader : IVideoUploader
    {
        private readonly IAuthenticationProvider _authProvider;
        private readonly IFileProvider _fileProvider;

        public YouTubeUploader(IAuthenticationProvider authProvider, IFileProvider fileProvider)
        {
            _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        public async Task<bool> UploadVideoAsync(string videoPath, VideoMetadata metadata)
        {
            var credential = await _authProvider.GetCredentialsAsync();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = (Google.Apis.Http.IConfigurableHttpClientInitializer)credential,
                ApplicationName = "YouTube Data API Sample"
            });

            var video = new Video
            {
                Snippet = new VideoSnippet
                {
                    Title = "Título Descriptivo del Video", // El título del video
                    Description = "Descripción detallada del contenido del video...", // Descripción del video
                    Tags = new string[] { "etiqueta1", "etiqueta2", "etiqueta3" }, // Etiquetas relevantes para el video
                    CategoryId = "27", // Elige la categoría adecuada (esto es un ejemplo; las categorías tienen sus propios ID)
                    DefaultLanguage = "es", // El idioma por defecto del video (código de idioma ISO 639-1)
                    DefaultAudioLanguage = "es", // El idioma por defecto del audio del video (código de idioma ISO 639-1)

                    // Los siguientes campos son opcionales y dependen de tu caso de uso específico
                    // PublishedAt = DateTime.Now, // La fecha y hora de publicación del video (opcional)
                    // ChannelId = "TU_CHANNEL_ID", // El ID del canal de YouTube donde se publicará el video (opcional)
                    // Thumbnails = new ThumbnailDetails(), // Detalles de la miniatura del video (opcional)
                    // Playlists = new List<string>() { "id_playlist1", "id_playlist2" }, // IDs de las listas de reproducción a las que se agregará el video (opcional)
                },
                Status = new VideoStatus { PrivacyStatus = metadata.Privacidad.ToString().ToLower() }
            };

            using (var fileStream = _fileProvider.GetFileStream(videoPath))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                //videosInsertRequest.ProgressChanged += VideosInsertRequest_ProgressChanged;
                //videosInsertRequest.ResponseReceived += VideosInsertRequest_ResponseReceived;

                var a = await videosInsertRequest.UploadAsync();

                return a.Status == Google.Apis.Upload.UploadStatus.Completed;
            }
        }

        //private void VideosInsertRequest_ProgressChanged(IUploadProgress progress)
        //{
        //    // Manejar el progreso de la subida aquí
        //}

        private void VideosInsertRequest_ResponseReceived(Video video)
        {
            // Manejar la respuesta aquí
        }
    }

}
