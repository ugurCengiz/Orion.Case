using Orion.Case.Core.Dtos;

namespace Orion.Case.Entities.Dtos
{
    public class GetListTelephoneDirectoryListItemDto : BaseDto
    {
        public int Id { get; set; }
        public required string CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public string? UpdatedUserId { get; set; }
        public string? UpdatedUser { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
