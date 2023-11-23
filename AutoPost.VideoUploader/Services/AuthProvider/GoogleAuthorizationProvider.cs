using AutoPost.VideoUploader.DTOs;
using AutoPost.VideoUploader.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Services.AuthProvider
{
    public class GoogleAuthorizationProvider : IAuthenticationProvider
    {
        private readonly string _credentialsFilePath;

        public GoogleAuthorizationProvider(string credentialsFilePath)
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
                    "user", // Un identificador único para el usuario que autoriza la aplicación
                    CancellationToken.None);
            }

        }
    }
}