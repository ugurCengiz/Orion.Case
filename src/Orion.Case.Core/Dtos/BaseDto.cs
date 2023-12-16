namespace Orion.Case.Core.Dtos
{
    public class BaseDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
