using System.ComponentModel.DataAnnotations;

namespace DormitoryManagement.Dtos
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
