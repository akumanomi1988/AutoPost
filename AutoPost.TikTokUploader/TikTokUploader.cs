using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.TikTokUploader
{
    public static class TikTokUploader
    {
        public static void Upload(TikTokParams _Params)
        {
            foreach (var fullFileName in Directory.EnumerateFiles(_Params.FilePath))
            {
                _Params.ScheduleTime = _Params.ScheduleTime.AddHours(1);
                var startInfo = CreateProcessStartInfo(_Params, fullFileName);
                ExecuteAndWaitForProcess(startInfo);
            }
        }

        private static ProcessStartInfo CreateProcessStartInfo(TikTokParams _Params, string fullFileName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "tiktok-uploader", // Asegúrate de que python esté en el PATH o especifica la ruta completa
                Arguments = BuildCommandArguments(_Params, fullFileName),
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            return startInfo;
        }
        private static void ExecuteAndWaitForProcess(ProcessStartInfo startInfo)
        {
            startInfo.RedirectStandardError = true; // Redirigir la salida de error

            using (Process process = Process.Start(startInfo))
            {
                // Espera a que el proceso externo finalice
                process.WaitForExit();

                // Leer la salida estándar
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine("Salida Estándar:");
                Console.WriteLine(output);

                // Leer la salida de error
                string error = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Salida de Error:");
                    Console.WriteLine(error);
                }
            }
        }
        private static string BuildCommandArguments(TikTokParams _Params, string fullFileName)
        {
            string tagsAsString = _Params.Tags != null && _Params.Tags.Any()
                ? " #" + string.Join(" #", _Params.Tags)
                : string.Empty;

            string videoTitleWithTags = $"{_Params.VideoTitle}{tagsAsString}";

            string commandArguments = $" -v \"{fullFileName}\"";

            if (!string.IsNullOrEmpty(videoTitleWithTags))
            {
                commandArguments += $" -d \"{videoTitleWithTags}\"";
            }

            if (_Params.ScheduleTime > DateTimeOffset.UtcNow.AddHours(1))
            {
                string formattedScheduleTime = _Params.ScheduleTime.ToString("yyyy-MM-dd HH:mm");
                commandArguments += $" -t \"{formattedScheduleTime}\"";
            }

            if (!string.IsNullOrEmpty(_Params.SessionID))
            {
                commandArguments += $" -s {_Params.SessionID}";
            }

            return commandArguments;
        }

        private static void ExecuteProcess(ProcessStartInfo startInfo)
        {
            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }




    }
}
