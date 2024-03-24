using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;
using DormitoryManagement.Utils;
using System.Diagnostics;

namespace DormitoryManagement.Pages.Booking
{
    public class BookingResultModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public BookingResultModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public Bed Bed { get; set; } = default!;

        public RoomAllocation? RoomAllocation { get; set; } = default!;
        public BookingRequest? BookingRequest { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            int? bedId = null;
            var User = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            var bookingRequest = await _context.BookingRequests.FirstOrDefaultAsync(b => b.ResidentId == User.UserId);
            var roomAllocation = await _context.RoomAllocations.FirstOrDefaultAsync(r => r.ResidentId == User.UserId);
            if (bookingRequest != null)
            {
                bedId = bookingRequest.BedId;
            }
            if (roomAllocation != null)
            {
                bedId = roomAllocation.BedId;
            }
            var bed = await _context.Beds
                .Include(m => m.Room)
                .Include(m => m.Room.Dormitory)
                .Include(m => m.Room.RoomType)
                .FirstOrDefaultAsync(m => m.BedId == bedId);

            Bed = bed;
            BookingRequest = bookingRequest;
            RoomAllocation = roomAllocation;

            return Page();
        }

    }
}
