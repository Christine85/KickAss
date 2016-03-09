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
        [Required(ErrorMessage ="Please enter a first name")]
        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Wrong Format")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        

    }
}
