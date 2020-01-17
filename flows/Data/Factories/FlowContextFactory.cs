using flows.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Data.Factories
{
    public class FlowContextFactory : IFlowContextFactory
    {
        public FlowDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlowDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FlowDbContext(optionsBuilder.Options);
        }
    }
}
