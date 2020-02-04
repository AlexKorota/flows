using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories.Interfaces
{
    public interface IBudgetRepository<T> : IGenericRepository<T> where T : Budget
    {
    }
}
