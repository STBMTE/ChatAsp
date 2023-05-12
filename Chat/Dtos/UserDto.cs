namespace Chat.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public ICollection<ChatroomDto> Chatrooms { get; set; } = new List<ChatroomDto>();
    }
}