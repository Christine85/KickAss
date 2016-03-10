using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Order
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }

        [Key]
        public int OrderId { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }       
    }
}
