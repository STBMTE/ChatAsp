using AutoMapper;
using Chat.Dtos;
using Chat.Models;

namespace Chat.Mapper
{
    public class ChatMessageMapper : Profile
    {
        public ChatMessageMapper() => CreateMap<ChatMessage, ChatMessageDTO>();
    }
}