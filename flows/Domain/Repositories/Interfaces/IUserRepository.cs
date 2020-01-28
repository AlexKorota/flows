using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetListAsync();

        Task CreateAsync(User user);

        Task<User> GetAsync(int id);
        Task<User> GetAsync(string email);
    }
}
