using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;

namespace AutoPost.Infraestructure.Instagram
{
    public class InstagramUploader : IPostPublisher
    {
        public async Task<bool> UploadVideoAsync(Post post)
        {
            await Task.Delay(100);
            return true;
            // Implementación específica para Instagram
        }
    }
}
