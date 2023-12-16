using Orion.Case.DataAccess.Abstract;
using Orion.Case.DataAccess.Contexts;
using Orion.Case.Entities.Concrete;

namespace Orion.Case.DataAccess.Concrete
{
    public class TelephoneDirectoryRepository : GenericRepository<TelephoneDirectory>, ITelephoneDirectoryRepository
    {
        public TelephoneDirectoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
