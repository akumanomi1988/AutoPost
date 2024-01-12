using AutoPost.Application.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace AutoPost.Application.Services
{
    //public class VideoUploadService : IPublishService
    //{
    //    private readonly IServiceProvider _serviceProvider;

    //    public VideoUploadService(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;
    //    }

       
    //    public async Task<PostData> PublishAsync(PostData post)
    //    { 
    //        foreach (var platform in post.PendingNetworks)
    //        {
    //            var uploader = _serviceProvider.GetRequiredService<IPostPublisherFactory>().CreatePublisher(platform.Name);
    //            if (await uploader.UploadPostAsync(post) == 3)
    //            {
    //                post.PendingNetworks.Remove(platform);
    //                post.PublishedNetworks.Add(platform);
    //            }
    //        }
    //        return post;
    //    }

        //public Task PublishAsync(Post post)
        //{
        //    throw new NotImplementedException();
        //}
    //}

}
