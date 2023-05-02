namespace Chat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public ICollection<Chatroom> Chatrooms { get; set; } = new List<Chatroom>();
    }
}