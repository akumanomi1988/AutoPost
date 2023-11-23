using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Interfaces
{
    internal interface IVideoUploaderFactory
    {
        IVideoUploader CreateUploader(string platform, IAuthenticationProvider authenticationProvider);
    }
}
