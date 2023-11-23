using AutoPost.VideoUploader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Services.FileProvider
{
    public class FileProvider : IFileProvider
    {
        public Stream GetFileStream(string path)
        {
            return new FileStream(path, FileMode.Open);
        }
    }
}

