using Microsoft.EntityFrameworkCore;
using Orion.Case.DataAccess.Contexts;
using System.Linq.Expressions;
using Orion.Case.Core.Repositories;

namespace Orion.Case.DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> _dbSet { get; set; }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await _dbSet.ToListAsync()
                : await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
