using Chat.Models;
using MediatR;

namespace Chat.Requests
{
    public record GetChatroomsRequest : IRequest<GetChatroomsResult>
    {
        public int UserId { get; init; }
    }
    
    public record GetChatroomsResult
    {
        public required Chatroom[] Chatrooms { get; init; }
    }
}