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
using System.Diagnostics;

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

        public string? Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Message = null;
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
            
            var User = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            var roomAllocation = _context.RoomAllocations.FirstOrDefault(r => r.ResidentId == User.UserId);
            var bRequest = _context.BookingRequests.FirstOrDefault(r => r.ResidentId == User.UserId);
            if (roomAllocation != null)
            {
                Message = "Booked";
                return Page();
            }
            if (bRequest !=null)
            {
                Message = "Requested";
                return Page();
            }

            int BedId;

            if (RoomAllocation.BedId != null)
            {

                BedId = (int) RoomAllocation.BedId;
                
            }
            else
            {
                return NotFound();
            }
            
            BookingRequest bookingRequest = new BookingRequest();
            bookingRequest.BedId = BedId;
            bookingRequest.ResidentId = User.UserId;

            _context.BookingRequests.Add(bookingRequest);
            _context.SaveChanges();

            return RedirectToPage("/Booking/BookingResult");

        }






    }
}
