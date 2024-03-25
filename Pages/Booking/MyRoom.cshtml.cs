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
    public class MyRoomModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public MyRoomModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int? DeleteAllocation { get; set; }
        public RoomAllocation RoomAllocation { get; set; } = default!;

        public string? Message { get; set; }


        public IActionResult OnGet()
        {

            Message = null;

            var User = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");
            if (User == null)
            {
                return Redirect("/Home");
            }

            RoomAllocation = _context.RoomAllocations
                .Include(r => r.Resident).Include(r => r.Bed).Include(r => r.Bed.Room).Include(r => r.Bed.Room.Dormitory).FirstOrDefault(r => r.ResidentId == User.UserId && r.MoveOutDate == null);
            if (RoomAllocation == null)
            {
                Message = "You haven't booked any room!";
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            var User = SessionUtil.GetObjectFromJson<User>(HttpContext.Session, "User");

            RoomAllocation = _context.RoomAllocations
               .Include(r => r.Resident).Include(r => r.Bed).Include(r => r.Bed.Room).Include(r => r.Bed.Room.Dormitory).FirstOrDefault(r => r.ResidentId == User.UserId);

            var allocation = _context.RoomAllocations.FirstOrDefault(r => r.AllocationId == RoomAllocation.AllocationId).MoveOutDate = DateTime.Now;
            _context.SaveChanges();

            return Redirect("/Booking/MyRoom");

        }
    }
}
