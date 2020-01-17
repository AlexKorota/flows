using flows.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Data
{
    public class FlowDbContext : DbContext
    {
        public FlowDbContext(DbContextOptions<FlowDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
