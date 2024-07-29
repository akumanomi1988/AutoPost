using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Downloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Application.Services
{
    public class VideoManagementService : IVideoManagementService
    {
        private readonly IVideoSplitter _VideoSplitter;
        private readonly IVideoCropper _VideoCropper    ;
        public VideoManagementService(IVideoSplitter VideoSplitter,IVideoCropper videoCropper)
        {
            _VideoSplitter = VideoSplitter;
            _VideoCropper = videoCropper;
        }
        public async Task SplitVideoByDuration(string videoPath, string outputPath, int splitDuration)
        {
            await _VideoSplitter.SplitVideoByDuration(videoPath, outputPath, splitDuration);
        }

        public async Task SplitVideoByNumberSplits(string videoPath, string outputPath, int numberOfSplits)
        {
            await _VideoSplitter.SplitVideoByNumberSplits(videoPath, outputPath, numberOfSplits);
        }
        public void CancelOperation()
        {
             _VideoSplitter.CancelOperation();
        }

        public  async Task CropVideo(string VideoPathInput, string VideoPathOutput)
        {
            await _VideoCropper.CropVideo(VideoPathInput,VideoPathOutput);
        }
    }
}
