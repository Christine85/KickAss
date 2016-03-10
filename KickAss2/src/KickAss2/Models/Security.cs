using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Security
    {
       
        public string Password { get; set; }

        [Key]
        public string Email { get; set; }
    }
}
