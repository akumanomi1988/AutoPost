
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
            //Google official example
            //UserCredential credential;
            //using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            //{
            //    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.Load(stream).Secrets,
            //        // This OAuth 2.0 access scope allows an application to upload files to the
            //        // authenticated user's YouTube channel, but doesn't allow other types of access.
            //        new[] { YouTubeService.Scope.YoutubeUpload },
            //        "user",
            //        CancellationToken.None
            //    );
            //}


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