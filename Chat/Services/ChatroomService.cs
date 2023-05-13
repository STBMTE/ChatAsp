using Chat.Models;
using Chat.Repositories;

namespace Chat.Services
{
    public class ChatroomService
    {
        private readonly ChatroomRepository _chatroomRepository;

        public ChatroomService(ChatroomRepository chatroomRepository)
        {
            _chatroomRepository = chatroomRepository;
        }
        
        public async ValueTask<IReadOnlyCollection<Chatroom>> GetChatroomsAsync(int userId) => await _chatroomRepository.GetChatrooms(userId);
    }
}