using Chat.Database;
using Chat.Models;

namespace Chat.Repositories
{
    public class UserRepository: RepositoryAsync<User>
    {
        protected UserRepository(ChatContext dbContext) : base(dbContext) { }
        
        public async ValueTask<User> GetUser(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}