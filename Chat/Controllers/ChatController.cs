using System.Diagnostics;
using AutoMapper;
using Chat.Database;
using Chat.Dtos;
using Chat.Models;
using Chat.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat.Controllers
{
    /// добавление пользователя, чата, сообщения;
    /// листинг пользователей, чатов, сообщений одного чата;
    /// мягкое удаление чатов и пользователей - вместо удаления из БД запись отмечается как удалённая;
    /// обновление названия чата, имени пользователя
    
    [ApiController] 
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ChatController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetChatroom(int id)
        {
            //Full Data Return
            //var data = _context.Authors.Include("Books").FirstOrDefault(y => y.id == id);
            // Pass Data Into DTO
            var authordata = _context.Chatroom.FirstOrDefault(x => x.Id == id);
            var authordtodata = _mapper.Map<ChatroomDto>(authordata);
            return Ok(authordtodata);
        }
        
        [HttpGet]
        public IActionResult GetChatrooms()
        {
            var chatroomdata = _context.Chatroom.ToList();
            var chatroomdtodata = _mapper.Map<List<ChatroomDto>>(chatroomdata);
            return Ok(chatroomdtodata);
        }
        
        [HttpPost("chatroom")]
        public IActionResult AddAuthors(ChatroomDto obj)
        {
            var added =  _context.Add(_mapper.Map<Chatroom>(obj));
            _context.SaveChanges();
            return CreatedAtAction("GetChatroom", new { id = obj.Id }, obj);
        }
        
        // [HttpGet("users")]
        // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        // {
        //     return await _context.Users.ToListAsync();
        // }
        //
        // [HttpGet("{id:int}/messages")]
        // public async Task<ActionResult<IEnumerable<ChatMessage>>> GetMessages(int id)
        // {
        //     var chatroom = await _context.Chatroom.FindAsync(id);
        //     if (chatroom == null)
        //         return NotFound();
        //
        //     return chatroom.Messages.ToList();
        // }
        //
        // [HttpGet("{id:int}")]
        // public async Task<ActionResult<Chatroom>> GetChatroom(int id)
        // {
        //     var chatroom = await _context.Chatroom.FindAsync(id);
        //
        //     if (chatroom == null)
        //         return NotFound();
        //
        //     return chatroom;
        // }
        //
        // [HttpGet("users/{id:int}")]
        // public async Task<ActionResult<User>> GetUser(int id)
        // {
        //     var user = await _context.Users.FindAsync(id);
        //
        //     if (user == null)
        //         return NotFound();
        //
        //     return user;
        // }
        //
        // [HttpGet("{chatId:int}/messages/{messageId}")]
        // public async Task<ActionResult<ChatMessage>> GetMessage(int chatId, long messageId)
        // {
        //     var chatroom = await _context.Chatroom.FindAsync(chatId);
        //     if (chatroom == null)
        //         return NotFound();
        //     
        //     return chatroom.Messages.FirstOrDefault(m => m.Chatroom == chatroom && m.Id == messageId);;
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Chatroom>> PostChatroom(Chatroom chatroom)
        // {
        //     _context.Chatroom.Add(chatroom);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction(nameof(GetChatroom), new { id = chatroom.Id }, chatroom);
        // }
        //
        // [HttpPost("users")]
        // public async Task<ActionResult<Chatroom>> PostUser(User user)
        // {
        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        // }
        //
        // [HttpPost("{id:int}/messages")]
        // public async Task<IActionResult> PostMessage(int id, ChatMessage chatMessage)
        // {
        //     if (chatMessage == null)
        //         return BadRequest();
        //     
        //     var chatroom = await _context.Chatroom.FindAsync(id);
        //     if (chatroom == null)
        //         return NotFound();
        //     
        //     chatroom.Messages.Add(chatMessage);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction(nameof(GetUser), new { id = chatMessage.Id }, chatMessage);
        // }
        //
        // [HttpPut("{id:int}")]
        // public async Task<IActionResult> PutChatroom(int id, Chatroom chatroom)
        // {
        //     if (id != chatroom.Id)
        //         return BadRequest();
        //
        //     _context.Entry(chatroom).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ChatroomExists(id))
        //             return NotFound();
        //         
        //         throw;
        //     }
        //
        //     return NoContent();
        // }
        //
        // [HttpPut("users/{id:int}")]
        // public async Task<IActionResult> PutUser(int id, User user)
        // {
        //     if (id != user.Id)
        //         return BadRequest();
        //
        //     _context.Entry(user).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!UserExists(id))
        //             return NotFound();
        //         
        //         throw;
        //     }
        //
        //     return NoContent();
        // }
        //
        // private bool ChatroomExists(int id) => _context.Chatroom.Any(e => e.Id == id);
        //
        // private bool UserExists(int id) => _context.Users.Any(e => e.Id == id);
        //
        // [HttpDelete("{id:int}")]
        // public async Task<IActionResult> DeleteChatroom(int id)
        // {
        //     var chatroom = await _context.Chatroom.FindAsync(id);
        //     if (chatroom == null)
        //         return NotFound();
        //
        //     _context.Chatroom.Remove(chatroom);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // [HttpDelete("users/{id:int}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     var user = await _context.Users.FindAsync(id);
        //     if (user == null)
        //         return NotFound();
        //
        //     //user            
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
    }
}