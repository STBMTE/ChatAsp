using AutoMapper;
using Chat.Dtos;
using Chat.Models;

namespace Chat.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>().ForMember(x => x.Chatrooms, options => options.Ignore());
        }
    }
}