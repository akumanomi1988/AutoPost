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
        private readonly IAuthenticationProvider _authProvider;
        private readonly IFileProvider _fileProvider;

        public YouTubePublisher(IAuthenticationProvider authProvider, IFileProvider fileProvider)
        {
            _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }


        //public async  Task<int> UploadPostAsync(PostData postData)
        //{
        //    var youtubeData = postData as YoutubePostData;
        //    if (youtubeData is null) { return -1; }
        //    var credential = (UserCredential)await _authProvider.GetCredentialsAsync();
        //    var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "YTUploader"
        //    });
        //    var video = new Video();
        //    video.Snippet = new VideoSnippet();
        //    video.Snippet.Title = youtubeData.Title;
        //    video.Snippet.Description = youtubeData.Description;
        //    video.Snippet.Tags = youtubeData.Tags.Select(x => x).ToArray();
        //    video.Snippet.CategoryId = youtubeData.Category; // See https://developers.google.com/youtube/v3/docs/videoCategories/list

        //    video.Status = new VideoStatus();
        //    //video.Status.PublishAtDateTimeOffset = DateTime.Now.AddMinutes(5);
        //    video.Status.PrivacyStatus = youtubeData.Privacy.ToString().ToLower(); // or "private" or "public"
        //    var filePath = youtubeData.ContentPath;

        //    using (var fileStream = new FileStream(filePath, FileMode.Open))
        //    {
        //        var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
        //        videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
        //        videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

        //        var res = await videosInsertRequest.UploadAsync();
        //        return (int) res.Status ;
        //    }
        //}

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
                return (int)res.Status;
            }
        }


        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;

                case UploadStatus.Failed:
                    Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    break;
            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {
            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }
    }
}


