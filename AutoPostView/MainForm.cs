using AutoPost.BingConnector;
using AutoPost.ChatGPTConnector.Interfaces;
using AutoPostChatGPTConnector.Model;

namespace AutoPostView
{
    public partial class MainForm : Form
    {
        private const string ModeloGPT = "gpt-3.5-turbo";
        private const string URLGPT = "https://api.openai.com/v1/chat/completions";

        private readonly IApiRequestService _apiRequestService;
        private ChatGPT? _chatGPT;
        public MainForm(IApiRequestService apiRequestService)
        {
            InitializeComponent();
            _apiRequestService = apiRequestService ?? throw new ArgumentNullException(nameof(apiRequestService));
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            //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
            try
            {

                if (_chatGPT == null)
                {
                    _chatGPT = new ChatGPT(txtApiKey.Text,
                                    URLGPT,
                                    ModeloGPT);
                }
                if (_chatGPT != null)
                {
                    _chatGPT.Prompt = textBox1.Text;
                    txtResponse.Text = await Request(_chatGPT);
                }
            }
            catch (Exception ex)
            {

                txtResponse.Text = ex.Message;
            }


        }

        private async Task<string> Request(ChatGPT gpt)
        {
            var response = await _apiRequestService.MakeApiRequest(gpt);
            return response.ToString();
        }

        private void btnSeeKey01_MouseDown(object sender, MouseEventArgs e)
        {
            txtApiKey.UseSystemPasswordChar = false;

        }

        private void btnSeeKey01_MouseUp(object sender, MouseEventArgs e)
        {
            txtApiKey.UseSystemPasswordChar = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var tw = new TwitterApiClient("xmp244eF8B7kJMA5Hsnuhtynq", "nL2SMmvmmv9fhVSkESIuRpKFm4y5pVbKwC85JCWUC35LcIfLeH", "1448172179208773632-7XVB5fwDpJq0fVDNfh4TUeH9qeqBxQ", "EL86FbzcfYxUOi4FQ3Tyv6H8YEwOBIzjWCuX9j6OyTYG4");
            if (tw == null) { return; }
            var uname = await tw.GetUserName();
            await tw.GetTrendingTopics();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] tags = new string[] {
                                        "fyp", "ForYouPage", "tiktokchallenge", "funny", "viral",
                                        "music", "dance", "trending", "love", "fashion",
                                        "beauty", "food", "diy", "travel", "fitness",
                                        "comedy", "lifestyle", "pets", "tutorial", "art",
                                        "gaming"
                                    };
            AutoPost.TikTokUploader.TikTokUploader.Upload(new AutoPost.TikTokUploader.TikTokParams("fcebce69048eb5d09c592c41f9e8c4a1", "C:\\Users\\dmozota\\Downloads\\Vid", "Sabes más que un niño de primaria", tags, DateTimeOffset.UtcNow.AddHours(1)));
        }
    }
}