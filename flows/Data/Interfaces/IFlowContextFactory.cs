using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Data.Interfaces
{
    public interface IFlowContextFactory
    {
        FlowDbContext CreateDbContext(string connectionString);
    }
}
