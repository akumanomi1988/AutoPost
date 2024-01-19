using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using System.Diagnostics;

namespace AutoPost.Infrastructure.TikTok
{
    public class TikTokUploader : IPostPublisher
    {
        private static string _SessionId = "";
        public TikTokUploader(string SessionID) { _SessionId = SessionID; }
        public async Task<int> UploadPostAsync(PostData postData)
        {
            var tikTokData = postData as TikTokPostData;
            if (tikTokData == null) return -1;

            var startInfo = CreateProcessStartInfo(tikTokData);
            if (startInfo == null) { return -1; }

            await ExecuteAndWaitForProcessAsync(startInfo);
            return 0; // Puedes modificar esto para devolver un código más significativo
        }

        //////private static ProcessStartInfo? CreateProcessStartInfo(TikTokPostData tikTokData)
        //////{
        //////    if (_SessionId == "") { return null; }

        //////    string tagsAsString = tikTokData.Tags != null && tikTokData.Tags.Any()
        //////        ? string.Join(" #", tikTokData.Tags)
        //////        : string.Empty;

        //////    string commandArguments = $" -i \"{_SessionId}\" -p \"{tikTokData.ContentPath}\" -t \"{tikTokData.Title}\"";

        //////    if (!string.IsNullOrEmpty(tagsAsString))
        //////    {
        //////        commandArguments += $" --tags \"#{tagsAsString}\"";
        //////    }

        //////    // Obteniendo la ruta del ejecutable
        //////    var executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //////    var executableDirectory = Path.GetDirectoryName(executablePath);
        //////    // Construyendo la ruta relativa al script .py
        //////    var scriptPath = Path.Combine(executableDirectory, "TikTok\\Tiktok_uploader.py");

        //////    return new ProcessStartInfo
        //////    {
        //////        FileName = "python",
        //////        Arguments = $"\"{scriptPath}\" {commandArguments}",
        //////        UseShellExecute = false,
        //////        RedirectStandardOutput = true,
        //////        RedirectStandardError = true
        //////    };
        //////}
        private static ProcessStartInfo? CreateProcessStartInfo(TikTokPostData tikTokData)
        {
            // Verificar si la ID de sesión está disponible
            if (string.IsNullOrEmpty(_SessionId))
            {
                return null;
            }

            // Construir la descripción, incluyendo los tags
            string descriptionWithTags = tikTokData.Title;
            if (tikTokData.Tags != null && tikTokData.Tags.Any())
            {
                string tagsAsString = string.Join(" ", tikTokData.Tags.Select(tag => $"#{tag.Trim()}"));
                descriptionWithTags += " " + tagsAsString;
            }

            // Construir los argumentos del comando
            string commandArguments = $"-v \"{tikTokData.ContentPath}\" -s \"{_SessionId}\" -d \"{descriptionWithTags}\"";

            // Aquí puedes agregar más argumentos según sea necesario

            // Construir y devolver ProcessStartInfo
            return new ProcessStartInfo
            {
                FileName = "tiktok-uploader", // Asegúrate de que este script esté accesible en el PATH o especifica la ruta completa
                Arguments = commandArguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
        }


        private static async Task ExecuteAndWaitForProcessAsync(ProcessStartInfo startInfo)
        {
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                await process.WaitForExitAsync();

                string output = await process.StandardOutput.ReadToEndAsync();
                Console.WriteLine("Salida Estándar:");
                Console.WriteLine(output);

                string error = await process.StandardError.ReadToEndAsync();
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Salida de Error:");
                    Console.WriteLine(error);
                }
            }
        }
    }
}
