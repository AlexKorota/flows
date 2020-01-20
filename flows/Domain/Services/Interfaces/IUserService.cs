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
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetCurrentUser(int id);
        Task<User> RegisterUserAsync(UserDTO dto);
    }
}
