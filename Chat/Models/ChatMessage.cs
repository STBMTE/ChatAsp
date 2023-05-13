using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public record ChatMessage
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public TimeSpan Date { get; set; }
        
        public User Sender { get; set; }
        public Chatroom Chatroom { get; set; }
    }
}