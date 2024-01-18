using AutoPost.Presentation.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{


    public class PostGeneratorSettingsController
    {
        private const string FileName = "PostGeneratorSettings.json";
        public void SavePostGeneratorSettings(PostGeneratorSettings postGeneratorSettings)
        {
            if (postGeneratorSettings == null) { return; }
            string jsonString = JsonSerializer.Serialize(postGeneratorSettings);
            File.WriteAllText(FileName, jsonString);
        }
        public PostGeneratorSettings? LoadPostGeneratorSettings()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<PostGeneratorSettings>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
