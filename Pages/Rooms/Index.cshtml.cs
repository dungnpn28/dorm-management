using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;

namespace DormitoryManagement.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public IndexModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Include(r => r.Dormitory)
                .Include(r => r.RoomType).ToListAsync();
            }
        }
    }
}
