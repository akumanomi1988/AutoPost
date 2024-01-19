
using AutoPost.Domain.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;
using Google.Apis.YouTube.v3;

namespace AutoPost.Infraestructure.Authentication
{
    public class GoogleAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string _credentialsFilePath;

        public GoogleAuthenticationProvider(string credentialsFilePath)
        {
            _credentialsFilePath = credentialsFilePath;
        }

        public async Task<object> GetCredentialsAsync()
        {
            using (var stream = new FileStream(_credentialsFilePath, FileMode.Open, FileAccess.Read))
            {
                var clientSecrets = NewtonsoftJsonSerializer.Instance.Deserialize<GoogleClientSecrets>(stream).Secrets;

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None);
            }

        }
    }
}