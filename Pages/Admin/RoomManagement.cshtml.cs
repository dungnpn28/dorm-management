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
        public IList<RoomType> RoomType { get; set; } = default!;
        public string DataMessage { get; set; }
        [BindProperty]
        public Room AddRoom { get; set; }




        public IActionResult OnGet()
        {
            if (_context.Rooms != null)
            {
                Room =  _context.Rooms
                .Include(r => r.Dormitory)
                .Include(r => r.RoomType)
                .ToList();
            }

            if (_context.Dormitories != null)
            {
                Dormitory =  _context.Dormitories.ToList();
            }
            if (_context.RoomTypes != null)
            {
                RoomType =  _context.RoomTypes.ToList();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            IQueryable<Room> query = _context.Rooms
                                    .Include(r => r.Dormitory)
                                    .Include(r => r.RoomType);

            Dormitory =  _context.Dormitories.ToList();

            if (_context.RoomTypes != null)
            {
                RoomType = _context.RoomTypes.ToList();
            }

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

            Room =  query.ToList();
            if (Room.Count == 0)
            {
                DataMessage = "No Rooms Found!";

            }

            if (AddRoom != null && AddRoom.RoomNumber != null) 
            {
                var newRoom = new Room();
                newRoom.AvailabilityStatus = 1;
                newRoom.RoomNumber = AddRoom.RoomNumber;
                newRoom.DormitoryId = AddRoom.DormitoryId;
                newRoom.Floor = AddRoom.Floor;
                newRoom.RoomTypeId = AddRoom.RoomTypeId;
                _context.Rooms.Add(newRoom);
                _context.SaveChanges();
                return Redirect("/Admin/RoomManagement");
            }


            return Page();
        }
    }
}
