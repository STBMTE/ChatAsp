using System.Linq.Expressions;
using Chat.Database;
using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Repositories
{
    public class ChatroomRepository : RepositoryAsync<Chatroom>
    {
        public ChatroomRepository(ChatContext dbContext) : base(dbContext) { }

        public async ValueTask<IReadOnlyCollection<Chatroom>> GetChatrooms(int userId)
        {
            // var chatrooms = await _dbContext.Chatrooms
            //     .Where(c => c.Users.Any(u => u.Id == userId))
            //     .Select(c => new 
            //     {
            //         Chatroom = c,
            //         LastMessage = c.Messages.OrderBy(m => m.Id).FirstOrDefault(),
            //         Sender = c.Messages.OrderBy(m => m.Id).FirstOrDefault().Sender,
            //     })
            //     .ToListAsync();
            
            // return await GetAll().Where(C => C.Users.Any(u => u.Id == userId))
            //     .Select(c => c)
            //     .ToListAsync();

            return await GetAll(c => c.Users.Any(u => u.Id == userId))
                .Include(c => c.Messages)
                .ToListAsync();

            // return await _dbContext.Set<Chatroom>().Where(c => c.Users.Any(u => u.Id == userId))
            //     .Include(c => c.Messages.OrderBy(m => m.Id).Take(1))
            //     .ThenInclude(m => m.Sender)
            //     .OrderBy(c => c.Id)
            //     .Skip(0 * 0)
            //     .Take(0)
            //     .ToArrayAsync();

            // return await GetAll(c => c.Users.Any(u => u.Id == userId))
            //     .Include(c => c.Messages.OrderBy(m  => m.Id).Take(1))
            //     .ThenInclude(m => m.Sender)
            //     .ToArrayAsync();
        }
    }
}