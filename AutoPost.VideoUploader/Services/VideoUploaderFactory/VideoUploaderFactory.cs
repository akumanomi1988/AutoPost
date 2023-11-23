using AutoPost.VideoUploader.Interfaces;
using AutoPost.VideoUploader.Services.VideoUploading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Services.VideoUploaderFactory
{
    public class VideoUploaderFactory : IVideoUploaderFactory
    {
        private readonly IFileProvider _fileProvider;

        public VideoUploaderFactory(
            IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IVideoUploader CreateUploader(string platform, IAuthenticationProvider authenticationProvider)
        {
            return platform switch
            {
                "YouTube" => new YouTubeUploader(authenticationProvider, _fileProvider),
                // "Instagram" => new InstagramUploader(authenticationProvider, _fileProvider),
                // "TikTok" => new TikTokUploader(authenticationProvider, _fileProvider),
                _ => throw new ArgumentException("Unsupported platform", nameof(platform)),
            };
        }
    }

}
