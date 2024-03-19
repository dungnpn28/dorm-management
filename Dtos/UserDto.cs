using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DormitoryManagement.Dtos
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".+@fpt\\.edu\\.vn$", ErrorMessage = "Email address must end with 'fpt.edu.vn'")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
