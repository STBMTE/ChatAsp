using AutoMapper;
using Chat.Database;
using Chat.Models;
using Chat.Requests;
using Chat.Services;
using MediatR;

namespace Chat.Handlers
{
    public class GetChatroomsHandler: IRequestHandler<GetChatroomsRequest, GetChatroomsResult>
    {
        private readonly IMapper _mapper;
        private readonly ChatroomService _chatroomService;

        public GetChatroomsHandler(IMapper mapper, ChatroomService chatroomService)
        {
            _chatroomService = chatroomService;
            _mapper = mapper;
        }

        public async Task<GetChatroomsResult> Handle(GetChatroomsRequest request, CancellationToken cancellationToken)
        {
            var chatrooms = await _chatroomService.GetChatroomsAsync(request.UserId);
            
            return new GetChatroomsResult() { Chatrooms = chatrooms.Select(c => _mapper.Map<Chatroom>(c)).ToArray()};
        }
    }
}