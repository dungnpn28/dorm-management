using DormitoryManagement.Models;
using DormitoryManagement.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Reflection.Metadata;

namespace DormitoryManagement.Pages.Account
{
    public class RegisterVerifyModel : PageModel
    {
        private readonly DormContext _context;

        public RegisterVerifyModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public bool IsVerified { get; set; }

        public string Message { get; set; }
        public void OnGet(string? tokenCode, string? mail)
        {
            if (tokenCode == null || mail == null)
            {
                Message = "Check your inbox to verify your mail!";
                IsVerified = false;
            }
            else
            {
                Message = "";
                var token = _context.RegisterTokens.FirstOrDefault(t => t.TokenCode.Equals(tokenCode));
                if (token == null)
                {
                    Message = "Verified failed. Maybe your token has expired?";
                    IsVerified = false;
                }
                else
                {
                    if (token.Mail.Equals(mail))
                    {
                        Message = "Verified Successfully!";
                        IsVerified = true;
                        User newUser = new User();
                        newUser.Name = token.Name;
                        newUser.Username = StringUtil.GetUserName(token.Mail);
                        newUser.StudentCode = StringUtil.GetStudentCode(token.Mail);
                        newUser.Mail = token.Mail.ToLower();
                        newUser.RoleId = 2;
                        newUser.Gender = token.Gender;
                        newUser.Dob = token.Dob;
                        newUser.Password = token.Password;
                        _context.Users.Add(newUser);
                        _context.SaveChanges();
                        _context.RegisterTokens.Remove(token);
                        _context.SaveChanges();
                    }
                    else
                    {
                        Message = "Verified failed. Maybe your token has expired?";
                        IsVerified = false;
                    }
                }
            }
        }
    }
}
