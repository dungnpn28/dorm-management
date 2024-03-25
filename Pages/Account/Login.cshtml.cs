using DormitoryManagement.Dtos;
using DormitoryManagement.Models;
using DormitoryManagement.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
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



        public IActionResult OnGet()
        {
            var User = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            if (User != null)
            {
                return Redirect("/");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                // Check if the provided username and password match a user in the database
                var userList = _context.Users.ToList();
                var user = userList.FirstOrDefault(u => u.Username.ToLower().Equals(UserDto.UserName) && u.Password.Equals(UserDto.Password, StringComparison.Ordinal));
                if (user == null)
                {
                    user = userList.FirstOrDefault(u => u.Mail.ToLower().Equals(UserDto.UserName) && u.Password.Equals(UserDto.Password, StringComparison.Ordinal));

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
                Debug.WriteLine("ModelState invalid - Login Page");
                return Page();
            }


        }

    }
}

