using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPostChatGPTConnector.Model
{
    public class ChatGPT
    {
        public readonly string ApiKey;
        public readonly string Model;
        public readonly string ApiUrl;
        public string Prompt { get; set; } = string.Empty;
        public ChatGPT(string apiKey, string apiUrl,string model,string prompt)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;
            Model = model;
            Prompt = prompt;
        }
        public ChatGPT(string apiKey, string apiUrl, string model)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;
            Model = model;
        }
    }
}
