using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DormitoryManagement.Models;
using DormitoryManagement.Dtos;

namespace DormitoryManagement.Pages.Booking
{
    public class ViewRoomModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public ViewRoomModel(DormitoryManagement.Models.DormContext context)
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

        public async Task OnPostAsync()
        {
            IQueryable<Room> query = _context.Rooms
                                    .Where(r => r.AvailabilityStatus != 0)
                                    .Include(r => r.Dormitory)
                                    .Include(r => r.RoomType);

            Dormitory = await _context.Dormitories.ToListAsync();



            int? SearchDormitoryId = string.IsNullOrEmpty(Request.Form["SearchDormitoryId"]) ? null : int.Parse(Request.Form["SearchDormitoryId"]);
            int? SearchFloor = string.IsNullOrEmpty(Request.Form["SearchFloor"]) ? null : int.Parse(Request.Form["SearchFloor"]);



            if (SearchDormitoryId != 0 && SearchDormitoryId != null)
            {
                query = query.Where(r => r.DormitoryId == SearchDormitoryId);
            }

            if (SearchFloor != null && SearchFloor != 0)
            {
                query = query.Where(r => r.Floor == SearchFloor);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(r => r.RoomNumber.Contains(search));
            }

            Room = await query.ToListAsync();
            if (Room.Count == 0)
            {
                DataMessage = "No Rooms Found!";

            }
        }
    }
}
