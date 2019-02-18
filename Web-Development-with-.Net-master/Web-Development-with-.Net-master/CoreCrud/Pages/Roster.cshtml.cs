using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace CoreCrud.Pages
{
    public class RosterModel : PageModel
    {
      private AppDbContext _context;
      public RosterModel(AppDbContext context) {
          _context = context;
      }
      
      public void OnGet()
      {
          Athletes = _context.Athlete.Include(x => x.Country).OrderBy(x => x.Country.Country_name).ToList();
      }
       public ICollection <Athlete> Athletes { get; set; }
    }
}