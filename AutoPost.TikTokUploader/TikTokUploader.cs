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
        private const string ProgramName= "Tiktok-uploader";

        public static void Upload(TikTokParams _Params)
        {
            foreach (var fullFileName in Directory.EnumerateFiles(_Params.FilePath).ToList())
            {
                _Params.ScheduleTime = _Params.ScheduleTime.AddHours(1);

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python"; // Asegúrate de que python esté en el PATH o especifica la ruta completa
                if (_Params.ScheduleTime > DateTimeOffset.UtcNow.AddHours(1)) 
                { 
                    start.Arguments = string.Format("{0} -i {1} -p {2} -v {3} --tags {4} -s {5}", ProgramName, _Params.SesionID, $"{fullFileName}", $"{_Params.VideoTitle}", string.Join(' ', _Params.Tags),_Params.ScheduleTime.ToUnixTimeSeconds());
                }
                else
                {
                    start.Arguments = string.Format("{0} -i {1} -p {2} -v {3} --tags {4}", ProgramName, _Params.SesionID, $"{fullFileName}", $"{_Params.VideoTitle}", string.Join(' ', _Params.Tags));
                }
                start.Arguments = $@"Tiktok-uploader -s fcebce69048eb5d09c592c41f9e8c4a1 -v 'C:\Users\dmozota\Downloads\Vid\12.mp4' -d 'Sabes más que un niño de primaria'";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;

                using (Process process = Process.Start(start))
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
}
