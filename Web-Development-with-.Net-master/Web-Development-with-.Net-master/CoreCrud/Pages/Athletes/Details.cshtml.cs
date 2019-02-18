using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Athletes
{
    public class DetailsModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public DetailsModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public Athlete Athlete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Athlete = await _context.Athlete
                .Include(a => a.Country).FirstOrDefaultAsync(m => m.Id == id);

            if (Athlete == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
