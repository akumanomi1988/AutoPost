using AutoPost.Presentation.Desktop.ViewModel;
using System.Text.Json;

namespace AutoPost.Presentation.Desktop.Controllers
{
    public class PostController
    {
        private const string FileName = "PostSettings.json";
        public PostController()
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
        public void Save(PostSettings Post)
        {
            if (Post == null) { return; }
            string jsonString = JsonSerializer.Serialize(Post);
            File.WriteAllText(FileName, jsonString);
        }

        public PostSettings? Load()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<PostSettings>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
