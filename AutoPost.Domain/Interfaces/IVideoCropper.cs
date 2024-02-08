using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Interfaces
{
    public interface IVideoCropper
    {
        /// <summary>
        /// Change 16:9 to 9:16 removing lateral bands
        /// </summary>
        /// <param name="VideoPathInput"></param>
        /// <param name="VideoPathOutput"></param>
        /// <returns></returns>
        Task CropVideo(string VideoPathInput, string VideoPathOutput);
    }
}
