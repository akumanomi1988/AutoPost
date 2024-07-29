using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Application.Interfaces
{
    public interface IVideoManagementService
    {
        Task SplitVideoByDuration(string videoPath, string outputPath, int splitDuration);
        Task SplitVideoByNumberSplits(string videoPath, string outputPath, int numberOfSplits);
        void CancelOperation();
        Task CropVideo(string VideoPathInput, string VideoPathOutput);
    }
}
