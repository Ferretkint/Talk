namespace TalkClient.Ui.Mvc.Models
{
    public class ChatChannel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
