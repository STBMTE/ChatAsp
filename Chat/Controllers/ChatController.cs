using AutoMapper;
using Chat.Database;
using Chat.Dtos;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Chat.Controllers
{
    /// добавление ,, сообщения;
    /// листинг ,, сообщений одного чата;
    /// обновление названия чата, имени пользователя
    
    [ApiController] 
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ChatController(DataContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        #region Chatroom

        [HttpGet("{id}")]
        public IActionResult GetChatroom(int id)
        {
            //Full Data Return
            //var data = _context.Authors.Include("Books").FirstOrDefault(y => y.id == id);
            // Pass Data Into DTO
            var chatroomData = _context.Chatroom.FirstOrDefault(x => x.Id == id); //TODO: added null check
            var chatroomDtoData = _mapper.Map<ChatroomDto>(chatroomData);
            return Ok(chatroomDtoData);
        }
        
        [HttpGet]
        public IActionResult GetChatrooms()
        {
            var chatroomData = _context.Chatroom.ToList(); //TODO: added check "delete"
            var chatroomDtoData = _mapper.Map<List<ChatroomDto>>(chatroomData);
            return Ok(chatroomDtoData);
        }
        
        [HttpPost("chatroom")]
        public IActionResult AddChatroom(ChatroomDto obj)
        {
            var added =  _context.Add(_mapper.Map<Chatroom>(obj));
            _context.SaveChanges();
            return CreatedAtAction("GetChatroom", new { id = obj.Id }, obj);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChatroom(int id)
        {
            var chatroomData = _context.Chatroom.FirstOrDefault(x => x.Id == id);
            chatroomData.Deleted = true; //TODO: added check null
            _context.SaveChanges();
            return Ok(); 
        }

        #endregion

        #region User

        [HttpGet("users")]
        //public Task<> GetAllUsers([FromQuery] crea request) => _mediator.Send(request);
        
        // [HttpGet("users")]
        // public IActionResult GetUsers()
        // {
        //     var userData = _context.Users.ToList(); //TODO: added check "delete"
        //     var userDtoData = _mapper.Map<List<UserDto>>(userData);
        //     return Ok(userDtoData);
        // }
        
        [HttpGet("users/{id}")]
        public IActionResult GetUser(int id)
        {
            //Full Data Return
            //var data = _context.Authors.Include("Books").FirstOrDefault(y => y.id == id);
            // Pass Data Into DTO
            var userData = _context.Users.FirstOrDefault(x => x.Id == id); //TODO: added null check
            var userDtoData = _mapper.Map<UserDto>(userData);
            return Ok(userDtoData);
        }

        [HttpPost("user")]
        public IActionResult AddUser(UserDto obj)
        {
            var added =  _context.Add(_mapper.Map<User>(obj));
            _context.SaveChanges();
            return CreatedAtAction("GetUser", new { id = obj.Id }, obj);
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userData = _context.Users.FirstOrDefault(x => x.Id == id);
            userData.Deleted = true; //TODO: added check null
            _context.Update(userData);
            _context.SaveChanges();
            return Ok(); //TODO: OK if delete = true
        }

        #endregion

        #region ChatMessage

        [HttpGet("{chatId}/messages")]
        public IActionResult GetChatMessages(int chatId)
        {
            var chatMessageData = _context.Chatroom.First(x => x.Id == chatId).Messages.ToList(); //TODO: added check "delete"
            var chatMessageDtoData = _mapper.Map<List<ChatMessageDTO>>(chatMessageData);
            return Ok(chatMessageDtoData);
        }
        
        [HttpPost("{chatId}/chatMessage")]
        public IActionResult AddUser(int chatId, ChatMessageDTO obj)
        {
            return null; //TODO: added
        }

        #endregion
    }
}