using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Athletes
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public CreateModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Country_name");
            return Page();
        }

        [BindProperty]
        public Athlete Athlete { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                 ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Country_name");
                return Page();
            }

            _context.Athlete.Add(Athlete);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}