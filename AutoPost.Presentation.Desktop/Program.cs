
using AutoMapper;
using AutoPost.Application.Interfaces;
using AutoPost.Application.Services;
using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Authentication;
using AutoPost.Infraestructure.Downloader;
using AutoPost.Infraestructure.Factories;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.VideoManagement;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Infrastructure.VideoManagement;
using AutoPost.Presentation.Desktop;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;

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
        _ = services.AddSingleton<ICategoryService, YouTubeCategoryService>();
        _ = services.AddSingleton<ICategoryService, InstagramCategoryService>();
        _ = services.AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider(GoogleAuthPath));
        _ = services.AddTransient<IPostPublisherFactory, PublisherFactory>();
        _ = services.AddTransient<CategoryManager>();
        _ = services.AddTransient<IVideoDownloader, YouTubeDownloader>();
        _ = services.AddTransient<IVideoDownloadService, VideoDownloadService>();
        _ = services.AddTransient<IVideoSplitter, VideoSplitter>();
        _ = services.AddTransient<IVideoCropper, VideoCropper>();
        _ = services.AddTransient<IVideoManagementService, VideoManagementService>();
        _ = services.AddAutoMapper(typeof(MapConfig));
        _ = services.AddTransient<MainForm>();
    }
}
