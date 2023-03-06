using TalkClient.Ui.Mvc.Models;

namespace TalkClient.Ui.Mvc.Services
{
    public class ChatChannelService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatChannelService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<ChatChannel>> FindAsync()
        {
            var client = _httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-channels";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var channels = await response.Content.ReadFromJsonAsync<IList<ChatChannel>>();

            return channels ?? new List<ChatChannel>();
        }

        public async Task<ChatChannel?> CreateAsync(ChatChannelRequest request)
        {
            var client = _httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-channels";

            var response = await client.PostAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ChatChannel>();
        }
    }
}
