using AutoPost.Presentation.Desktop.ViewModel;
using System.Text.Json;

namespace AutoPost.Presentation.Desktop.Controllers
{


    public class PostAnimatorController
    {
        private const string FileName = "PostGeneratorSettings.json";

        public PostAnimatorController()
        {
            if (!File.Exists(FileName))
            {
                try
                {
                    Save(new());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Save(PostAnimatorSettings postGeneratorSettings)
        {
            if (postGeneratorSettings == null) { return; }
            string jsonString = JsonSerializer.Serialize(postGeneratorSettings);
            File.WriteAllText(FileName, jsonString);
        }
        public PostAnimatorSettings? Load()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<PostAnimatorSettings>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
