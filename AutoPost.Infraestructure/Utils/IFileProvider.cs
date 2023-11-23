
namespace AutoPost.Infraestructure.Utils
{
    public interface IFileProvider
    {
        Stream GetFileStream(string path);
    }
}
