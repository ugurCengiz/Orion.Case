using Orion.Case.Core.Dtos;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create
{
    public class CreateTelephoneDirectoryResponse : BaseDto
    {
        public int Id { get; set; }
        public string CreatedUserId { get; set; }
        public string? UpdatedUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
