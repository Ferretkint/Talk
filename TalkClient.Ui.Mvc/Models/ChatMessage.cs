namespace TalkClient.Ui.Mvc.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public required string Author { get; set; }
        public required string Message { get; set; }
        public required string Channel { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
