using System.Text.Json.Serialization;

namespace Chat.Models
{
    public record User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        
        public ICollection<Chatroom> Chatrooms { get; set; }
    }
}