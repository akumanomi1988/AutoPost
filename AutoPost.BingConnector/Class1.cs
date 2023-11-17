using BingChat;
namespace AutoPost.BingConnector
{
    public class Class1
    {
        public async Task<string> llama()
        {
            
            var cookie = "1sB8PFwq10vKi3UKz0Vo_ZhT3Kp3igZPH-7ar8Y0Im8HaGesUF-Mc6ZLIpect5tjM3IBJ65SWw70D1dDqHHyjVFkyD6DBNlGXbNR4TXDxSGY62fovcQMCECKoMKhFhUw90d1nV_X8sC1TfM_J228PLtLNd9pu8h-UMedlWJu6_10zb9wbX9AEL26UuddQz14q4slYj1_3U5PCyDrLWWzV_-cBIK3cPiSyzEXkcz2-B0k";
            var options = new BingChatClientOptions { Tone = BingChatTone.Creative, CookieU = cookie };
            var client = new BingChatClient(options);
            var conversacion = client.CreateConversation();
            var message = "Hola";
            var answer = await client.AskAsync(message);
            return answer;
        }

    }
}