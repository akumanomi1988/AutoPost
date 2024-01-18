using AutoPost.Domain.Models;
using AutoPost.Presentation.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{
    public class PostController
    {
        private const string FileName = "PostSettings.json";
        public PostController() { }
        public void SavePost(Post Post)
        {
            if (Post == null) { return; }
            string jsonString = JsonSerializer.Serialize(Post);
            File.WriteAllText(FileName, jsonString);
        }

        public Post? LoadPost() 
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<Post>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
