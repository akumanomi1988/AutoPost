using AutoPost.Domain.Interfaces;
using AutoPost.View;
using Microsoft.Extensions.DependencyInjection;


namespace AutoPost.Presentation
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
                .AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider("C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPostView\\Secrets\\GoogleAuth.json"))
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