using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Order
    {
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public int OrderId { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }       
    }
}
