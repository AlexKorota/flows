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

        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string hashPassword);

        Task<List<User>> GetList();
    }
}
