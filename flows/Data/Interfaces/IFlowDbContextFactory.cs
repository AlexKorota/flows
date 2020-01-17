using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Data.Interfaces
{
    public interface IFlowDbContextFactory
    {
        FlowDbContext CreateDbContext(string connectionString);
    }
}
