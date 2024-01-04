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
    public class YouTubeUploader : IPostPublisher
    {
        private readonly IAuthenticationProvider _authProvider;
        private readonly IFileProvider _fileProvider;

        public YouTubeUploader(IAuthenticationProvider authProvider, IFileProvider fileProvider)
        {
            _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        public async Task<bool> UploadVideoAssssync( VideoMetadata metadata)
        {
            var credential = (UserCredential)await _authProvider.GetCredentialsAsync();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YTUploader"
            });
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = metadata.Title;
            video.Snippet.Description = metadata.Description;
            video.Snippet.Tags = metadata.Tags.Select(x => x.Text).ToArray();
            video.Snippet.CategoryId = metadata.CategoryId; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            
            video.Status = new VideoStatus();
            video.Status.PublishAtDateTimeOffset = metadata.DateProgram;
            video.Status.PrivacyStatus = metadata.Privacy.ToString().ToLower(); // or "private" or "public"
            var filePath = metadata.VideoPath; 

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                var res = await videosInsertRequest.UploadAsync();
                return res.Status ==  UploadStatus.Completed;
            }

        }

        public async  Task<int> UploadVideoAsync(Post metadata)
        {
            var credential = (UserCredential)await _authProvider.GetCredentialsAsync();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YTUploader"
            });
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = metadata.Title;
            video.Snippet.Description = metadata.Description;
            video.Snippet.Tags = metadata.Tags.Select(x => x).ToArray();
            video.Snippet.CategoryId = metadata.Category; // See https://developers.google.com/youtube/v3/docs/videoCategories/list

            video.Status = new VideoStatus();
            //video.Status.PublishAtDateTimeOffset = DateTime.Now.AddMinutes(5);
            video.Status.PrivacyStatus = metadata.Privacy.ToString().ToLower(); // or "private" or "public"
            var filePath = metadata.ContentPath;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                var res = await videosInsertRequest.UploadAsync();
                return (int) res.Status ;
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


