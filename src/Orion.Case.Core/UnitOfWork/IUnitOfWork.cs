namespace Orion.Case.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
