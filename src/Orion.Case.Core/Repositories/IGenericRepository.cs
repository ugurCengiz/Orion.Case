using System.Linq.Expressions;

namespace Orion.Case.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? predicate = null);
    }
}
