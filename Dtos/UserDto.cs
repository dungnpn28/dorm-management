using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DormitoryManagement.Dtos
{
    public class UserDto
    {
       
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
