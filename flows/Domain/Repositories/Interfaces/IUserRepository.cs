using flows.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task Update(User user);

        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);

        Task<List<User>> GetList();
    }
}
