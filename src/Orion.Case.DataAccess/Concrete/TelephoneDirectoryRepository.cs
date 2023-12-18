using Microsoft.EntityFrameworkCore;
using Orion.Case.DataAccess.Abstract;
using Orion.Case.DataAccess.Contexts;
using Orion.Case.Entities.Concrete;
using Orion.Case.Entities.Dtos;

namespace Orion.Case.DataAccess.Concrete
{
    public class TelephoneDirectoryRepository : GenericRepository<TelephoneDirectory>, ITelephoneDirectoryRepository
    {
        private AppDbContext _context;
        public TelephoneDirectoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetListTelephoneDirectoryListItemDto>> GetListDetail()
        {
            var list = await (from td in _context.TelephoneDirectories
                              join user in _context.Users on td.CreatedUserId equals user.Id
                              join upUser in _context.Users on td.UpdatedUserId equals upUser.Id
                              where td.IsDeleted == false
                              select new GetListTelephoneDirectoryListItemDto()
                              {
                                  Id = td.Id,
                                  Name = td.Name,
                                  LastName = td.LastName,
                                  CreatedUserId = td.CreatedUserId,
                                  CreatedUser = user.UserName,
                                  CreatedDate = td.CreatedDate,
                                  IsDeleted = td.IsDeleted,
                                  PhoneNumber = td.PhoneNumber,
                                  UpdatedDate = td.UpdatedDate,
                                  UpdatedUser = upUser.UserName,
                                  UpdatedUserId = td.UpdatedUserId
                              }).ToListAsync();

            return list;
        }

    }
}
