
using AutoPost.Application.Services;
using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Authentication;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.Utils;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Infrastructure.Factories;
using AutoPost.Infrastructure.TikTok;
using AutoPost.Presentation.Desktop;
using Microsoft.Extensions.DependencyInjection;

static class Program
{
    //Estos parametros de momento los dejo aquí, pero habrá que meterlos en configuración de la aplicación
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

        string liteDbPath = $@"{Application.StartupPath}\Database.db";
        string GoogleAuthPath = $@"{Application.StartupPath}\GoogleAuth.json";


        //services.AddSingleton<IMetadataStorageService>(provider => new MetadataStorageService(liteDbPath));
        services.AddSingleton<ICategoryService, YouTubeCategoryService>();
        services.AddSingleton<ICategoryService, InstagramCategoryService>();
        //services.AddTransient<IMetadataService,MetadataService>();
        services.AddTransient<IPostPublisherFactory, VideoUploaderFactory>();
        services.AddTransient<CategoryManager>();
        services.AddTransient<YouTubePublisher>();
        services.AddTransient<InstagramUploader>();
        services.AddTransient<TikTokUploader>();
        services.AddSingleton<IAuthenticationProvider, GoogleAuthenticationProvider>(provider =>
                    new GoogleAuthenticationProvider(GoogleAuthPath));
        services.AddSingleton<IFileProvider, FileProvider>();
        //services.AddTransient<IPublishService, VideoUploadService>();
        services.AddTransient<MainForm>();
    }
}
