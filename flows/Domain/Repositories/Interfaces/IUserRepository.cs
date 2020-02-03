using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories.Interfaces
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : User
    {
    }
}
