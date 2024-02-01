using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.Youtube;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPost.Infraestructure.Factories
{
    public class VideoUploaderFactory : IPostPublisherFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public VideoUploaderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPostPublisher CreatePublisher(string platform)
        {
            switch (platform.ToLower())
            {
                case "youtube":
                    IAuthenticationProvider authProvider = _serviceProvider.GetRequiredService<IAuthenticationProvider>();
                    return new YouTubePublisher(authProvider);
                case "tiktok":
                    return new TikTokPublisher(); //(authProvider, fileProvider);
                case "instagram":
                    return new InstagramUploader();
                // otros casos...

                default:
                    throw new ArgumentException($"La plataforma '{platform}' no es soportada.", nameof(platform));
            }
        }
    }

}
