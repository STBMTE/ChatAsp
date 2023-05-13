using Chat.Models;
using Chat.Repositories;

namespace Chat.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async ValueTask<User> GetUserAsync(int id) => await _userRepository.GetUser(id);
    }
}