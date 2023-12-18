using Orion.Case.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Orion.Case.Entities.Concrete
{
    public class TelephoneDirectory:BaseEntity
    {
        public int Id { get; set; }
        public required string CreatedUserId { get; set; }
        public string? UpdatedUserId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }        
        public required string PhoneNumber { get; set; }
    }
}
