

namespace AutoPost.Domain.Interfaces
{
    public interface IAuthenticationProvider
    {
            Task<object> GetCredentialsAsync();
       
    }
}
