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
    public class DeleteModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public DeleteModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Athlete = await _context.Athlete.FindAsync(id);

            if (Athlete != null)
            {
                _context.Athlete.Remove(Athlete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
