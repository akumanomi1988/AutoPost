using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Infraestructure.Utils;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace AutoPost.Infraestructure.Youtube
{
    public class YouTubePublisher : IPostPublisher
    {
        public event ProcessOutputHandler? OnProcessOutput;
        private readonly IAuthenticationProvider _authProvider;

        public YouTubePublisher(IAuthenticationProvider authProvider)
        {
            _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
        }

        public async Task<int> UploadPostAsync(PostData postData)
        {
            // Convertir a YoutubePostData
            if (postData is not YoutubePostData youtubeData)
            {
                return -1; // Retorna -1 si postData no es del tipo YoutubePostData
            }

            // Obtener credenciales y configurar el servicio de YouTube
            var credential = (UserCredential)await _authProvider.GetCredentialsAsync();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YTUploader"
            });

            // Configurar los detalles del video
            var video = new Video
            {
                Snippet = new VideoSnippet
                {
                    Title = youtubeData.Title,
                    Description = youtubeData.Description,
                    Tags = youtubeData.Tags.ToArray(),
                    CategoryId = youtubeData.Category // Asegúrate de que esto corresponda al ID de categoría de YouTube
                },
                Status = new VideoStatus
                {
                    PrivacyStatus = youtubeData.Privacy.ToLower() // "private", "public", "unlisted"
                }
            };

            // Subir el video
            var filePath = youtubeData.ContentPath;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                var res = await videosInsertRequest.UploadAsync();
                OnProcessOutput?.Invoke($"YOUTUBE PUBLISH RESULTS:\n{DateTime.Now.ToShortTimeString}\n{res.Status}");
                return (int)res.Status;
            }
        }


        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    //Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    OnProcessOutput?.Invoke($"YOUTUBE PUBLISH PROGRESS:\n{DateTime.Now.ToShortTimeString}\n{progress.BytesSent}");
                    break;

                case UploadStatus.Failed:
                    //Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    OnProcessOutput?.Invoke($"YOUTUBE PUBLISH PROGRESS:\n{DateTime.Now.ToShortTimeString}\n{progress.Exception}");
                    break;
            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {
            OnProcessOutput?.Invoke($"YOUTUBE PUBLISH RESULTS:\n{DateTime.Now.ToShortTimeString}\n{video.Id}\n{video.Kind}");
        }
    }
}


