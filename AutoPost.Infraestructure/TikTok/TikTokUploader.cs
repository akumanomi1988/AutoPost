using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;


namespace AutoPost.Infraestructure.TikTok
{
    public class TikTokUploader : IPostPublisher
    {
        public async Task<bool> UploadVideoAsync( Post Post)
        {
            await Task.Delay(100);
            return true;
            // Implementación específica para TikTok
        }
    }
}
