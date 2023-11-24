
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
using AutoPost.Infraestructure.MetadataStorage;
using Microsoft.Extensions.Configuration;
using AutoPost.Infrastructure.Factories;

static class Program
{
    //Estos parametros de momento los dejo aquí, pero habrá que meterlos en configuración de la aplicación
    const string liteDbPath = "C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPost.Presentation.Desktop\\Database.db";
    const string GoogleAuthPath = "C:\\Users\\dmozota\\source\\repos\\akumanomi1988\\AutoPost\\AutoPost.Presentation.Desktop\\GoogleAuth.json";
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var services = new ServiceCollection();
        ConfigureServices(services);
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        
        services.AddSingleton<IMetadataStorageService>(provider => new MetadataStorageService(liteDbPath));
        services.AddSingleton<ICategoryService, YouTubeCategoryService>();
        services.AddSingleton<ICategoryService, InstagramCategoryService>();
        services.AddTransient<IMetadataService,MetadataService>();
        services.AddTransient<IVideoUploaderFactory, VideoUploaderFactory>();
        services.AddTransient<CategoryManager>();
        services.AddTransient<YouTubeUploader>();
        services.AddTransient<InstagramUploader>();
        services.AddTransient<TikTokUploader>();
        services.AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider(GoogleAuthPath));
        services.AddSingleton<IFileProvider, FileProvider>();
        services.AddTransient<IVideoUploadService, VideoUploadService>();
        services.AddTransient<MainForm>();
    }
}
