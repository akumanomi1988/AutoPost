
namespace AutoPost.Infraestructure.Utils
{
    public class FileProvider : IFileProvider
    {
        public Stream GetFileStream(string path)
        {
            return new FileStream(path, FileMode.Open);
        }
    }
}

