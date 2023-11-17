using AutoPost.ChatGPTConnector.Interfaces;
using AutoPostChatGPTConnector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.ChatGPTConnector.Services
{
    public class ApiRequestService : IApiRequestService
    {
        private readonly HttpClient _httpClient;

        public ApiRequestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> MakeApiRequest(ChatGPT chatGPT)
        {
            if (chatGPT is null)
            {
                throw new ArgumentException("ChatGPT cannot be null.", nameof(chatGPT));
            }

            if (string.IsNullOrEmpty(chatGPT.ApiUrl))
            {
                throw new ArgumentException("API URL cannot be null or empty.", nameof(chatGPT.ApiUrl));
            }

            if (string.IsNullOrEmpty(chatGPT.Model))
            {
                throw new ArgumentException("Model cannot be null or empty.", nameof(chatGPT.Model));
            }

            if (string.IsNullOrEmpty(chatGPT.ApiKey))
            {
                throw new ArgumentException("API key cannot be null or empty.", nameof(chatGPT.ApiKey));
            }

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, chatGPT.ApiUrl)
                {
                    Content = new StringContent(chatGPT.Prompt, Encoding.UTF8, "application/json")
                };

                request.Headers.Clear();
                request.Headers.Add("Authorization", $"Bearer {chatGPT.ApiKey}");

                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors as needed
                Console.WriteLine($"Error making API request: {ex.Message}");
                throw;
            }
        }

    }
}
