using AutoPost.Presentation.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{
    public class PostUploaderSettingsController
    {
        private const string FileName = "PostUploaderSetting.json";
        public PostUploaderSettingsController() { }
        public PostUploaderSettings? GetPostUploaderSettings()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<PostUploaderSettings>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void SavePostUploaderSettings(PostUploaderSettings postUploaderSettings)
        {
            if (postUploaderSettings == null) { return; }
            string jsonString = JsonSerializer.Serialize(postUploaderSettings);
            File.WriteAllText(FileName, jsonString);
        }
    }
}
