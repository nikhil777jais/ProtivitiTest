namespace ProtivitiTest.WebAPI.DTOs
{
    public class BaseDto
    {
        public Guid? Id { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; } = DateTime.Now;
    }
}
