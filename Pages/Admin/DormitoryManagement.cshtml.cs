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
    public class DormitoryManagementModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public DormitoryManagementModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string search { get; set; }
        public IList<Room> Room { get; set; } = default!;
        public IList<Dormitory> Dormitory { get; set; } = default!;
        public string DataMessage { get; set; }


        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Where(r => r.AvailabilityStatus != 0)
                .Include(r => r.Dormitory)
                .Include(r => r.RoomType)
                .ToListAsync();
            }

            if (_context.Dormitories != null)
            {
                Dormitory = await _context.Dormitories.ToListAsync();
            }
        }
    }
}
