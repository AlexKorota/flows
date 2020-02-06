using flows.Data;
using flows.Data.Interfaces;
using flows.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace flows.Domain.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly FlowsDbContext _context;

        public GenericRepository(FlowsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cToken = default)
        {

            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        }

        public async Task<TEntity> FindByIdAsync(int id, CancellationToken cToken = default)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cToken = default)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task CreateAsync(TEntity item, CancellationToken cToken = default)
        {

            await _context.Set<TEntity>().AddAsync(item);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(TEntity item, CancellationToken cToken = default)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity item, CancellationToken cToken = default)
        {
            _context.Set<TEntity>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cToken = default)
        {
            var dbSet = _context.Set<TEntity>();
            dbSet.RemoveRange(dbSet.AsNoTracking().Where(predicate).ToList());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(CancellationToken cToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate, CancellationToken cToken = default,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Task.Run(() => Include(includeProperties).Where(predicate).ToList()); // Проверить корректность работы. Не уверен в верности реализации
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
