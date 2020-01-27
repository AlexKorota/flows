using flows.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class BaseRepository
    {
        protected string _connectionString { get; }
        protected IFlowDbContextFactory _contextFactory { get; }
        public BaseRepository(string connectionString, IFlowDbContextFactory contextFactory)
        {
            _connectionString = connectionString;
            _contextFactory = contextFactory;
        }
    }
}
