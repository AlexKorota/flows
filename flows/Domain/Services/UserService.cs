using flows.Domain.Models;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.Create(user);
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            User user = await _userRepository.GetByEmailAndPassword(email, hashPassword);
            if (user == null)
                throw new NullReferenceException("User not found");
            return user;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await _userRepository.GetList();

        }
    }
}
