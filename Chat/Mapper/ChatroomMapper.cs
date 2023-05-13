using AutoMapper;
using Chat.Dtos;
using Chat.Models;

namespace Chat.Mapper
{
    public class ChatroomMapper : Profile
    {
        public ChatroomMapper()
        {
            CreateMap<Chatroom, ChatroomDto>();
            CreateMap<ChatroomDto, Chatroom>().ForMember(x => x.Messages, options => options.Ignore());
        }
    }
}