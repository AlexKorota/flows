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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString, IFlowDbContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<List<User>> GetList()
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Users.ToListAsync();
            }
        }
        public async Task Create(User user)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
        }
    }
}
