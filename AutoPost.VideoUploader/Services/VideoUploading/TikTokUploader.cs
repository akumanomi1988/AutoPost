using AutoPost.VideoUploader.DTOs;
using AutoPost.VideoUploader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Services.VideoUploading
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
