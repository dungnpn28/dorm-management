using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;

namespace DormitoryManagement.Pages.Admin
{
    public class UserManagementModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public UserManagementModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        [BindProperty]
        public int? UserId { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users
                .Include(u => u.Role).ToListAsync();
            }
        }

        public IActionResult OnPost()
        {
            if (UserId != null)
            {
                var User = _context.Users.FirstOrDefault(u => u.UserId == UserId);
                if (User.RoleId == 2)
                {
                    _context.Users.FirstOrDefault(u => u.UserId == UserId).RoleId = 1;
                    _context.SaveChanges();
                }

            }
            return Redirect("/Admin/UserManagement");
        }
    }
}
