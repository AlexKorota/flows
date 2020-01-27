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

        public Task<List<User>> GetList()
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return context.Users.ToListAsync();
            }
        }
        public Task Create(User user)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                context.Users.Add(user);
                return context.SaveChangesAsync();
            }
        }

        public Task<User> GetByEmailAndPassword(string email, string hashPassword)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == hashPassword);
            }
        }

        public Task<User> GetByEmail(string email)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public Task<User> GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
        }
    }
}
