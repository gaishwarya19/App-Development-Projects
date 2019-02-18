using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Athletes
{
    public class EditModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public EditModel(CoreCrud.Models.AppDbContext context)
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
           ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Athlete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteExists(Athlete.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AthleteExists(int id)
        {
            return _context.Athlete.Any(e => e.Id == id);
        }
    }
}
