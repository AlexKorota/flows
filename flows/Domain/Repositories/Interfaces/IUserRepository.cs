using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetList();

        Task Create(User user);

        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string hashPassword);

    }
}
