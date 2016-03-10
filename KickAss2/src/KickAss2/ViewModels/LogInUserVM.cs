using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class LogInUserVM
    {
        [Required(ErrorMessage ="Ange mail-adress")]
        [EmailAddress(ErrorMessage ="fel format")]
        public string Email { get; set; }
        [Required(ErrorMessage ="ange lösenord")]
        public string Password { get; set; }
    }
}
