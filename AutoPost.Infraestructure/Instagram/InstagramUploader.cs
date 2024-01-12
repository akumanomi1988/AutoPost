using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;

namespace AutoPost.Infraestructure.Instagram
{
    public class InstagramUploader : IPostPublisher
    {
        public async Task<int> UploadPostAsync(PostData post)
        {
            await Task.Delay(100);
            return 0;
            // Implementación específica para Instagram
        }
    }
}
