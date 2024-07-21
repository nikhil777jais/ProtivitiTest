namespace ProtivitiTest.WebAPI.Models
{
    public class Customer : BaseModel
    {
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Avatar { get; set; }
    }
}
