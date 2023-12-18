using Orion.Case.Entities.Concrete;
using Orion.Case.Core.Repositories;
using Orion.Case.Entities.Dtos;

namespace Orion.Case.DataAccess.Abstract
{
    public interface ITelephoneDirectoryRepository : IGenericRepository<TelephoneDirectory>
    {
        Task<IEnumerable<GetListTelephoneDirectoryListItemDto>> GetListDetail();
    }
}
