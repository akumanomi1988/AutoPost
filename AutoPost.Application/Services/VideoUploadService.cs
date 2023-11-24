using AutoPost.Application.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPost.Application.Services
{
    public class VideoUploadService : IVideoUploadService
    {
        private readonly IServiceProvider _serviceProvider;

        public VideoUploadService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task UploadVideoAsync(string platform, VideoMetadata metadata)
        {
            var uploader = _serviceProvider.GetRequiredService<IVideoUploaderFactory>().CreateUploader(platform);
            await uploader.UploadVideoAsync( metadata);
        }
    }

}
