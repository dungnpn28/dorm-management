using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;
using DormitoryManagement.Utils;

namespace DormitoryManagement.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public MyProfileModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public IActionResult OnGet()
        {
            var us = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            if (us == null)
            {
                return Redirect("/");
            }
            User = _context.Users.FirstOrDefault(u => u.UserId == us.UserId);
            return Page();
        }
    }
}
