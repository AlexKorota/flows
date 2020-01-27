using flows.Domain.DTO;
using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace flows.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetCurrentUser(int id);
        Task<UserDTO> RegisterUserAsync(UserDTO dto);
        Task<IReadOnlyCollection<Claim>> GetUserIdentity(CredentialsDTO dto);
    }
}
