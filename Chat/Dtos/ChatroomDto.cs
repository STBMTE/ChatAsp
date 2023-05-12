namespace Chat.Dtos
{
    public class ChatroomDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
        public ICollection<ChatMessageDTO> Messages { get; set; } = new List<ChatMessageDTO>();
    }
}