using flows.Data;
using flows.Data.Interfaces;
using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class BudgetRepository : GenericRepository<Budget> 
    {
        public BudgetRepository(FlowsDbContext context) : base(context) { }
    }
}
