using AutoPost.Domain.Models;

namespace AutoPost.Domain.Interfaces
{
    public delegate void ProcessOutputHandler(string output);
    public interface IPostPublisher
    {
        event ProcessOutputHandler? OnProcessOutput;
        Task<int> UploadPostAsync(PostData post);

    }
}
