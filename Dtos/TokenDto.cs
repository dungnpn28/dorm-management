using System.ComponentModel.DataAnnotations;

namespace DormitoryManagement.Dtos
{
    public class TokenDto
    {
        [Required(ErrorMessage ="Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.*[A-Z]).{6,}$", ErrorMessage = "Password must contain at least one uppercase letter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@fpt\.edu\.vn$", ErrorMessage = "Must use FPT Email!")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime Dob { get; set; }

    }
}
