
using AutoPost.Application.Services;
using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Authentication;
using AutoPost.Infraestructure.Factories;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.Utils;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Presentation.Desktop;
using Microsoft.Extensions.DependencyInjection;

internal static class Program
{
    //Estos parametros de momento los dejo aquí, pero habrá que meterlos en configuración de la aplicación
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ServiceCollection services = new();
        ConfigureServices(services);
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        MainForm mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
    private static void ConfigureServices(IServiceCollection services)
    {

        string liteDbPath = $@"{Application.StartupPath}\Database.db";
        string GoogleAuthPath = $@"{Application.StartupPath}\GoogleAuth.json";


        //services.AddSingleton<IMetadataStorageService>(provider => new MetadataStorageService(liteDbPath));
        _ = services.AddSingleton<ICategoryService, YouTubeCategoryService>();
        _ = services.AddSingleton<ICategoryService, InstagramCategoryService>();
        //services.AddTransient<IMetadataService,MetadataService>();
        _ = services.AddTransient<IPostPublisherFactory, VideoUploaderFactory>();
        _ = services.AddTransient<CategoryManager>();
        _ = services.AddTransient<YouTubePublisher>();
        _ = services.AddTransient<InstagramUploader>();
        _ = services.AddTransient<TikTokPublisher>();
        _ = services.AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider(GoogleAuthPath));
        _ = services.AddSingleton<IFileProvider, FileProvider>();
        //services.AddTransient<IPublishService, VideoUploadService>();
        _ = services.AddTransient<MainForm>();
    }
}
