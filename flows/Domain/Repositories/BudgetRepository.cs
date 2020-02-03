using flows.Data.Interfaces;
using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class BudgetRepository<T> : GenericRepository<T> where T : Budget
    {
        public BudgetRepository(string connectionString, IFlowDbContextFactory contextFactory) : base(connectionString, contextFactory) { }
    }
}
