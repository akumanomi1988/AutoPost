using AutoPost.Presentation.Desktop.ViewModel;
using System.Text.Json;

namespace AutoPost.Presentation.Desktop.Controllers
{
    public class VideoRecorderController
    {
        private const string FileName = "VideoRecorder.json";
        public VideoRecorderController()
        {
            if (!File.Exists(FileName))
            {
                try
                {
                    Save(new VideoRecorderSettings());
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        public VideoRecorderSettings? Load()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<VideoRecorderSettings>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Save(VideoRecorderSettings videoRecorderSettings)
        {
            if (videoRecorderSettings == null) { return; }
            string jsonString = JsonSerializer.Serialize(videoRecorderSettings);
            File.WriteAllText(FileName, jsonString);
        }


    }
}
