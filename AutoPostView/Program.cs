using AutoPost.ChatGPTConnector.Interfaces;
using AutoPost.ChatGPTConnector.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

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
                .AddTransient<IApiRequestService, ApiRequestService>()
                .AddTransient<MainForm>()
                .BuildServiceProvider())
            {
                // Crear el formulario y pasar la dependencia del servicio
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
}


}