using AutoMapper;
using Chat.Dtos;
using Chat.Models;

namespace Chat.Mapper;

public class AllMappersProfile: Profile
{
    public AllMappersProfile()
    {
        CreateMap<Chatroom, ChatroomDto>();
        CreateMap<User, UserDto>();
        CreateMap<ChatMessage, ChatMessageDTO>();
        
        CreateMap<ChatroomDto, Chatroom>().ForMember(x=>x.Messages , options=>options.Ignore());
    }
}