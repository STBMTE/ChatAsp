using AutoMapper;
using Chat.Database;
using Chat.Dtos;
using Chat.Models;
using Chat.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Получить чаты пользователя
        /// </summary>
        [HttpGet]
        public Task<GetChatroomsResult> GetChatrooms([FromQuery] GetChatroomsRequest getChatroomsRequest) =>
            _mediator.Send(getChatroomsRequest);
    }
}