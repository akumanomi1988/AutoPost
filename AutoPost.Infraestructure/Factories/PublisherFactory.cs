using AutoPost.Domain.Enums;
using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.Youtube;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AutoPost.Infraestructure.Factories
{
    public delegate IPostPublisher PublisherFactoryDelegate(SocialMediaPlatform platform);
    public class PublisherFactory : IPostPublisherFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PublisherFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPostPublisher CreatePublisher(string platform)
        {
            return platform.ToLower() switch
            {
                "youtube" => CreateYouTubePublisher(),
                "tiktok" => CreateTikTokPublisher(),
                "instagram" => CreateInstagramPublisher(),
                _ => throw new ArgumentException($"La plataforma '{platform}' no es soportada.", nameof(platform)),
            };
        }

        private IPostPublisher CreateYouTubePublisher()
        {
            var authProvider = _serviceProvider.GetRequiredService<IAuthenticationProvider>();
            return new YouTubePublisher(authProvider);
        }

        private IPostPublisher CreateTikTokPublisher()
        {
            return new TikTokPublisher();
        }

        private IPostPublisher CreateInstagramPublisher()
        {
            return new InstagramPublisher();
        }
    }
}
