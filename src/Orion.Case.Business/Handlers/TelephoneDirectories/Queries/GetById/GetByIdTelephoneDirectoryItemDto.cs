using Orion.Case.Core.Dtos;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetById
{
    public class GetByIdTelephoneDirectoryItemDto : BaseDto
    {
        public int Id { get; set; }
        public required string CreatedUser { get; set; }
        public string? UpdatedUser { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
