namespace Chat.Models
{
    public record Chatroom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Deleted { get; set; }
        
        public ICollection<User> Users { get; set; }
        public ICollection<ChatMessage> Messages { get; set; }
    }
}