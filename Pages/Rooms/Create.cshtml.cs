using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DormitoryManagement.Models;

namespace DormitoryManagement.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly DormitoryManagement.Models.DormContext _context;

        public CreateModel(DormitoryManagement.Models.DormContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DormitoryId"] = new SelectList(_context.Dormitories, "DormitoryId", "DormitoryId");
        ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "RoomTypeId", "RoomTypeId");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rooms == null || Room == null)
            {
                return Page();
            }

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
