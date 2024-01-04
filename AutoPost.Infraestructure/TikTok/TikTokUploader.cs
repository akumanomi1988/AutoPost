using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;


namespace AutoPost.Infraestructure.TikTok
{
    public class TikTokUploader : IPostPublisher
    {
        public async Task<int> UploadVideoAsync( Post Post)
        {
            await Task.Delay(100);
            return 0;
            // Implementación específica para TikTok
        }
    }
}
