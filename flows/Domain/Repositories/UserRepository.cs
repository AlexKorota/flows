using flows.Data;
using flows.Data.Interfaces;
using flows.Domain.Entities;
using flows.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(string connectionString, IFlowDbContextFactory contextFactory) : base(connectionString, contextFactory) { }
    }
}
