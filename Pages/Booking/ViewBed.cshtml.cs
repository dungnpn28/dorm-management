using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;
using Microsoft.IdentityModel.Tokens;
using DormitoryManagement.Utils;

namespace DormitoryManagement.Pages.Booking
{
    public class ViewBedModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public ViewBedModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public Room Room { get; set; } = default!;
        public IList<Bed> Beds { get; set; } = default!;

        [BindProperty]
        public RoomAllocation RoomAllocation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Dormitory)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.RoomId == id);

            var beds = await _context.Beds
                .Where(b => b.RoomId == id)
                .Include(b => b.Room)
                .ToListAsync();

            if (room == null)
            {
                return NotFound();
            }
            else
            {
                Room = room;
            }
            if (beds.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                Beds = beds;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            if (user != null)
            {
                RoomAllocation.MoveInDate = DateTime.Now;
                RoomAllocation.ResidentId = user.UserId;
                _context.Add(RoomAllocation);
                await _context.SaveChangesAsync();
                return RedirectToPage("/BookingResult?result=1");
            } 
            
        }
    }
}
