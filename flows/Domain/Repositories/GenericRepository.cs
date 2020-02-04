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
        protected string _connectionString { get; }
        protected IFlowDbContextFactory _contextFactory { get; }

        public GenericRepository(string connectionString, IFlowDbContextFactory contextFactory)
        {
            _connectionString = connectionString;
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> FindByIdAsync(int id, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
            }
        }

        public async Task CreateAsync(TEntity item, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                await context.Set<TEntity>().AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                context.Entry(item).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(TEntity item, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                context.Set<TEntity>().Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cToken = default)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                var dbSet = context.Set<TEntity>();
                dbSet.RemoveRange(dbSet.AsNoTracking().Where(predicate).ToList());
                await context.SaveChangesAsync();
            }
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
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
                return includeProperties
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
        }
    }
}
