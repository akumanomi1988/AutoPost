using AutoPostChatGPTConnector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.ChatGPTConnector.Interfaces
{
    public interface IApiRequestService
    {
        Task<string> MakeApiRequest(ChatGPT chatGPT);
    }
}
