using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;


namespace AutoPost.Infraestructure.TikTok
{
    public class TikTokUploader : IVideoUploader
    {
        public async Task<bool> UploadVideoAsync(string videoPath, VideoMetadata metadata)
        {
            await Task.Delay(100);
            return true;
            // Implementación específica para TikTok
        }
    }
}
