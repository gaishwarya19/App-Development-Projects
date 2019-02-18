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
    public class IndexModel : PageModel
    {

        private AppDbContext _context;
        public IndexModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet()
        {
           CountOfAthletes =_context.Athlete.Count();
                            
           CountOfWins =_context.Athlete.
                            Where(x=>x.win==true).Count();    
           CountOfLosses =_context.Athlete.
                            Where(x=>x.win==false).Count();   
           
           CountOfCountries = _context.Country.Count();
        }
        public int CountOfAthletes { get; set; }
        public int CountOfWins { get; set; }
        public int CountOfLosses { get; set; }
        public int CountOfCountries { get; set; }
   
    }
}
