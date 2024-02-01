using AutoPost.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Application.Interfaces
{
    public interface IVideoDownloadService
    {
        Task<VideoDownloadResultDto> DownloadVideoAsync(string videoUrl, string downloadPath);
    }
}
