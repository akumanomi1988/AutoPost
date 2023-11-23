using AutoPost.VideoUploader.Interfaces;
using AutoPost.VideoUploader.Services.AuthProvider;
using AutoPost.VideoUploader.Services.FileProvider;
using AutoPost.VideoUploader.Services.VideoUploading;
using AutoPost.View;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Tweetinvi.Client;

namespace AutoPostView
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuración de inyección de dependencias
            using (var serviceProvider = new ServiceCollection()
                .AddSingleton<IAuthenticationProvider, GoogleAuthorizationProvider>(provider =>
                    new GoogleAuthorizationProvider("C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPostView\\Secrets\\GoogleAuth.json"))
                .AddSingleton<IFileProvider, FileProvider>()
                .AddTransient<IVideoUploader, YouTubeUploader>()
                .AddTransient<frmUploaderTest>()
                .BuildServiceProvider())
            {
                // Crear el formulario y pasar la dependencia del servicio
                var mainForm = serviceProvider.GetRequiredService<frmUploaderTest>();
                Application.Run(mainForm);
            }
        }
    }

}