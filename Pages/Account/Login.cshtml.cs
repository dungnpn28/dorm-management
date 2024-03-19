using DormitoryManagement.Dtos;
using DormitoryManagement.Models;
using DormitoryManagement.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace DormitoryManagement.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly DormContext _context;

        [BindProperty]
        public UserDto UserDto { get; set; }

        public LoginModel(DormContext context)
        {
            _context = context;
        }



        public void OnGet()
        {
            HttpContext.Session.Remove("User");
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                // Check if the provided username and password match a user in the database
                var user = _context.Users.FirstOrDefault(u => u.Username == UserDto.UserName && u.Password == UserDto.Password);

                if (user == null)
                {
                    user = _context.Users.FirstOrDefault(u => u.Mail == UserDto.UserName && u.Password == UserDto.Password);

                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password");
                        return Page();
                    }
                    else
                    {
                        SessionUtil.SetObjectAsJson(HttpContext.Session, "User", user);
                        return RedirectToPage("/Home");
                    }
                }
                else
                {
                    SessionUtil.SetObjectAsJson(HttpContext.Session, "User", user);
                    return RedirectToPage("/Home");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "ModelState is not valid for some reason?");
                return Page();
            }


        }

    }
}

