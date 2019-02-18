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
    public class CountryProfileModel : PageModel
    {
        private AppDbContext _context;
        public CountryProfileModel(AppDbContext context) {
            _context = context;
        }
       public Country CountryProfiles {get;set;}       
   
      public IActionResult Onget(int? id)
      {
        if(id== null)
        {
            return NotFound();
        }
         CountryProfiles = _context.Country.Include(x=>x.Athletes).FirstOrDefault(x => x.Id== id);
         if(CountryProfiles == null)
         {
            return NotFound();
         }                     
        return Page();        
      }
    }
}