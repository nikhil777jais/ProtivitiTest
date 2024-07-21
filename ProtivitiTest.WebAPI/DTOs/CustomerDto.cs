using System.ComponentModel.DataAnnotations;

namespace ProtivitiTest.WebAPI.DTOs
{
    public class CustomerDto: BaseDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format. Please enter a valid date.")]
        public DateOnly DateOfBirth { get; set; }

        public string? Avatar { get; set; }
    }
}
