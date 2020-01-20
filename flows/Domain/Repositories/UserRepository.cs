using flows.Data;
using flows.Domain.Models;
using flows.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FlowDbContext _context;
        public UserRepository(FlowDbContext context)
        {
            _context = context;
        }
        public Task Create(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }
        public Task Update(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChangesAsync();
        }

        public Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User> GetById(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<User>> GetList()
        {
            return _context.Users.ToListAsync();
        }
    }
}
