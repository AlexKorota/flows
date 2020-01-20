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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.Create(user);
            return user;
        }

        public Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
