using Orion.Case.Core.Entities;

namespace Orion.Case.Entities.Concrete
{
    public class TelephoneDirectory:BaseEntity
    {
        public int Id { get; set; }
        public required string CreatedUser { get; set; }
        public string? UpdatedUser { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
