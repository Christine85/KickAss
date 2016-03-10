using KickAss2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class CreateUserVM
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Ange förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Ange efternamn")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Du måste ange en e-mail")]
        [EmailAddress(ErrorMessage = "Felaktigt format")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Bekräfta lösenord")]
        [CompareAttribute("Email",ErrorMessage ="mailadresses matchar inte!")]
        public string VerifiedEmail { get; set; }

        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage ="Ange ett lösenord")]
        public string Password { get; set; }
        
        [Display(Name ="Bekräfta lösenord")]
        [Required(ErrorMessage = "Bekräfta lösenord")]
        [CompareAttribute("Password", ErrorMessage = "Lösenorden stämmer inte överens!")]
        public string VerifiedPassword { get; set; }

    }
}
