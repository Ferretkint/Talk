namespace TalkClient.Ui.Mvc.Models
{
    public class ChatViewModel
    {
        public IList<ChatChannel> Channels { get; set; } = new List<ChatChannel>();
        public IList<ChatMessage> Messages { get;set; } = new List<ChatMessage>();
    }
}
