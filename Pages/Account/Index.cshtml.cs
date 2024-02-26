using DormitoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DormitoryManagement.Pages.Account
{
    public class IndexModel : PageModel
    {
        User user = null;
        public void OnGet()
        {
            user = new User();
        }

        public void OnPost()
        {
            
        }
    }
}
