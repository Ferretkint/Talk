using TalkClient.Ui.Mvc.Models;

namespace TalkClient.Ui.Mvc.Services
{
    public class ChatMessageService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatMessageService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IList<ChatMessage>> FindAsync(string? channel)
        {
            var client = _httpClientFactory.CreateClient("TalkApi");
            var route = $"api/chat-messages?channel={channel}";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var messages =  await response.Content.ReadFromJsonAsync<IList<ChatMessage>>();

            return messages ?? new List<ChatMessage>();
        }
    }
}
