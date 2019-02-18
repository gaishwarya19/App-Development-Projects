
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Athlete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Please enter 2 - 100 characters")]
        [Display(Name = "First Name")]
        public string athlete_name { get; set; }
        
        public static ValidationResult StartDateInPastOrNearFuture(DateTime? game_start_time, ValidationContext context) {
        if (game_start_time == null) {
            return ValidationResult.Success;
        }
        DateTime futureDate = DateTime.Today.AddMonths(6);
        if (game_start_time < futureDate) {
            return ValidationResult.Success;
        }
        return new ValidationResult($"Start date must be before {futureDate.ToShortDateString()}");
        }
            
        [CustomValidation(typeof(Athlete), "StartDateInPastOrNearFuture")]
        [DataType(DataType.Date)]  
        [Display(Name = "Game Start Time")]
        public DateTime game_start_time { get; set; }      

        public static ValidationResult gameEndTimeCheck(DateTime? game_end_time, ValidationContext context) {
            if (game_end_time == null) {
                return ValidationResult.Success;
            }
            if (game_end_time < DateTime.Now) {
                return ValidationResult.Success;
            }
            return new ValidationResult("game End Time must be in the past");
        }
        [DataType(DataType.Date)]
        [Display(Name = "Game End Time")]
        [CustomValidation(typeof(Athlete), "gameEndTimeCheck")]
        public DateTime? game_end_time { get; set; }
      
        [Display(Name = "Game Won")]
        public bool win  { get; set; }
         
        [Display(Name = "Street Address")]
         public string Address{get;set;}
        [Display(Name = "State")]
        public string State {get;set;}
        [Display(Name = "City")]
        public string City {get;set;}
        
        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress {get; set; }
        [Required]
        [RegularExpression(@"^[\d]{5}$")]
        [Display(Name = "Zip")]
        public string Zip {get;set;}
      
        [Range(0, 100 , ErrorMessage = "Score must be valid number")]
        public int Score { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        // ADD PROPERTIES HERE
    }
}
            