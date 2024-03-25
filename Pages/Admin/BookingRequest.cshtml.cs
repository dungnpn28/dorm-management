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
    public class BookingRequestModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public BookingRequestModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public IList<BookingRequest> BookingRequest { get; set; } = default!;
        [BindProperty]
        public int? BookId { get; set; }
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.BookingRequests != null)
            {
                BookingRequest = await _context.BookingRequests
                    .Include(b => b.Resident)
                    .Include(b => b.Bed)
                    .Include(b => b.Bed.Room.Dormitory)
                    .ToListAsync();
            } 
            if (BookingRequest.Count <= 0)
            {
                Message = "No pending requests!";
            }
        }

        public IActionResult OnPost()
        {
            if (BookId != null)
            {
                var bookRequest = _context.BookingRequests.FirstOrDefault(b => b.BookId == BookId);
                if (bookRequest != null)
                {
                    var roomAllocation = _context.RoomAllocations.FirstOrDefault(r => r.ResidentId == bookRequest.ResidentId && r.BedId == bookRequest.BedId);
                    if (roomAllocation == null)
                    {
                        var newRoomAllocation = new RoomAllocation();
                        newRoomAllocation.BedId = bookRequest.BedId;
                        newRoomAllocation.ResidentId = bookRequest.ResidentId;
                        newRoomAllocation.MoveInDate = DateTime.Now;
                        _context.RoomAllocations.Add(newRoomAllocation);
                        _context.SaveChanges();
                        _context.BookingRequests.Remove(bookRequest);
                        _context.SaveChanges();
                    }
                }
            }
            return Redirect("/Admin/BookingRequest");
        }
    }
}
