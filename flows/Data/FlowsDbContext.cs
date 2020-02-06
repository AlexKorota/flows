using flows.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Data
{
    public class FlowsDbContext : DbContext
    {
        public FlowsDbContext(DbContextOptions<FlowsDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<ExpensesGroup> ExpensesGroups { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Budget>();

            builder.Entity<Expense>();

            builder.Entity<ExpensesGroup>();
        }
    }
}
