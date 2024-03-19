using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;

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

        public async Task<IActionResult> OnGetAsync(int? bedId)
        {
            if (bedId == null || _context.Beds == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds
                .Include(m => m.Room)
                .Include(m => m.Room.Dormitory)
                .Include(m => m.Room.RoomType)
                .FirstOrDefaultAsync(m => m.BedId == bedId);
            if (bed == null)
            {
                return NotFound();
            }
            else 
            {
                Bed = bed;
            }
            return Page();
        }
    }
}
