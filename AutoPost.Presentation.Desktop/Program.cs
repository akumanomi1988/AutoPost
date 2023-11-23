
using Microsoft.Extensions.DependencyInjection;
using AutoPost.Application.Services;
using AutoPost.Application.Interfaces;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.Utils;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Infraestructure.Authentication;
using AutoPost.Presentation.Desktop;
using AutoPost.Domain.Interfaces;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Configura el contenedor de servicios
        var services = new ServiceCollection();
        ConfigureServices(services);

        // Crea un proveedor de servicios
        using (var serviceProvider = services.BuildServiceProvider())
        {
            // Crea y muestra el formulario principal
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICategoryService, YouTubeCategoryService>();
        services.AddSingleton<ICategoryService, InstagramCategoryService>();
        services.AddTransient<CategoryManager>();
        services.AddTransient<YouTubeUploader>();
        services.AddTransient<InstagramUploader>();
        services.AddTransient<TikTokUploader>();
        services.AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider("C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPost.Presentation.Desktop\\GoogleAuth.json"));// ("C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPost.Presentation.Desktop\\GoogleAuth.json");
        services.AddSingleton<IFileProvider, FileProvider>();
        services.AddTransient<IVideoUploadService, VideoUploadService>();
        services.AddTransient<MainForm>();
    }
}
