using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{
    // En Presentation/Controllers
    public class VideoController 
    {
        private readonly IVideoDownloadService _videoDownloadService;

        public VideoController(IVideoDownloadService videoDownloadService)
        {
            _videoDownloadService = videoDownloadService;
        }

        [HttpPost]
        public async Task<IActionResult> DownloadVideo(string videoUrl)
        {
            var result = await _videoDownloadService.DownloadVideoAsync(videoUrl);
            return Ok(result);
        }
    }

}
