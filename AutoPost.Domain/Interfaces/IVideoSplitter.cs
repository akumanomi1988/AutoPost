using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Interfaces
{
    public interface IVideoSplitter
    {

        Task SplitVideoByDuration(string videoPath, string outputPath, int splitDuration);
        Task SplitVideoByNumberSplits(string videoPath, string outputPath, int numberOfSplits);
        void CancelOperation();
    }
}
