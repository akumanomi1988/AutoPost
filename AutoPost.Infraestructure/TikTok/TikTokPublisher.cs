using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using System.Diagnostics;

namespace AutoPost.Infrastructure.TikTok
{
    public class TikTokPublisher : IPostPublisher
    {
        public string SessionID { get; set; } = "";

        public event ProcessOutputHandler? OnProcessOutput;

        public async Task<int> UploadPostAsync(PostData postData)
        {
            var tikTokData = postData as TikTokPostData;
            if (tikTokData == null) return -1;

            var startInfo = CreateProcessStartInfo(tikTokData);
            if (startInfo == null) { return -1; }

            await ExecuteAndWaitForProcessAsync(startInfo);
            return 0;
        }

        private ProcessStartInfo? CreateProcessStartInfo(TikTokPostData tikTokData)
        {
            // Verificar si la ID de sesión está disponible
            if (SessionID == string.Empty)
            {
                OnProcessOutput?.Invoke($"TIKTOK UPLOAD RESULTS:No SessionId Configured");
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
            string commandArguments = $"-v \"{tikTokData.ContentPath}\" -s \"{SessionID}\" -d \"{descriptionWithTags}\"";

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


        private async Task ExecuteAndWaitForProcessAsync(ProcessStartInfo startInfo)
        {
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                await process.WaitForExitAsync();

                string output = await process.StandardOutput.ReadToEndAsync();

                output += await process.StandardError.ReadToEndAsync();

                if (!string.IsNullOrEmpty(output))
                {
                    OnProcessOutput?.Invoke($"TIKTOK UPLOAD RESULTS:{DateTime.Now.ToShortTimeString}\n{output}");
                }
            }
        }
    }
}
