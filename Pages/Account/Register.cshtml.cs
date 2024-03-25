using DormitoryManagement.Dtos;
using DormitoryManagement.Models;
using DormitoryManagement.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DormitoryManagement.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly DormContext _context;

        public RegisterModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }
        [BindProperty]
        public TokenDto tokenDto { get; set; }
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
            if (!ModelState.IsValid)
            {
                if (DateTime.Today.AddYears(-18) < tokenDto.Dob)
                {
                    ModelState.AddModelError("tokenDto.Dob", "You must be at least 18 years old.");
                    return Page();
                }
                return Page();

            }
            else
            {
                var existToken = _context.RegisterTokens.FirstOrDefault(r => r.Mail.ToLower().Equals(tokenDto.Mail.ToLower()));
                if (existToken != null)
                {
                    _context.RegisterTokens.Remove(existToken);
                    _context.SaveChanges();
                }

                var registerToken = new RegisterToken();
                registerToken.Password = tokenDto.Password;
                registerToken.TokenCode = TokenUtil.GenerateToken();
                registerToken.Dob = tokenDto.Dob;
                registerToken.Gender = tokenDto.Gender;
                registerToken.Mail = tokenDto.Mail;
                registerToken.Name = tokenDto.Name;
                registerToken.ExpireDate = DateTime.Now.AddMinutes(15);
                _context.RegisterTokens.Add(registerToken);
                _context.SaveChanges();

                MailUtil.SendVerificationEmail(registerToken.TokenCode, registerToken.Mail);
                return Redirect("/Account/RegisterVerify");


            }
        }
    }
}
