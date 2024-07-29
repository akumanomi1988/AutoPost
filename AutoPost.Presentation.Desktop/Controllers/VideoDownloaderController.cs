using AutoPost.Application.Interfaces;

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

        //public async Task<IActionResult> DownloadVideo(string videoUrl)
        //{
        //    var result = await _videoDownloadService.DownloadVideoAsync(videoUrl);
        //    return Ok(result);
        //}
    }

}
