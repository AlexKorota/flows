using flows.Domain.DTO;
using flows.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<List<UserDTO>> GetUsers();
        Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}
