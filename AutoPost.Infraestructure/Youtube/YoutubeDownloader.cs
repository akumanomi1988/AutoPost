using AutoPost.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Infraestructure.Youtube
{
    // En Infrastructure/Services
    public class YouTubeDownloader : IYouTubeDownloader
    {
        public async Task<string> DownloadVideoAsync(string videoUrl, string downloadPath)
        {
            
        }
    }
}
