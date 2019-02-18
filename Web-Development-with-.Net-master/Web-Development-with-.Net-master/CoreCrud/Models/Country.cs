
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCrud.Models
{
    public class Country
    {
         [Key]
        public int Id { get; set; }     
        public string Country_name{get;set;}
        public string Nationality {get;set;}
        public int Population { get;set; }
               
        public ICollection<Athlete> Athletes {get;set;}
        // ADD PROPERTIES HERE
    }
}
            