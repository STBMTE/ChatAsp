namespace Chat.Dtos;

public class ChatMessageDTO
{
    public long Id { get; set; }
    public string Message { get; set; }
    public TimeSpan Date { get; set; }
        
    public UserDto Sender { get; set; }
    public ChatroomDto Chatroom { get; set; }
}