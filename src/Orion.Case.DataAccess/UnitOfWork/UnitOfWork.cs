
using Orion.Case.Core.UnitOfWork;
using Orion.Case.DataAccess.Contexts;

namespace Orion.Case.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
