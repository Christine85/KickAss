using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class ProductInOrder
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [Key]
        public int OrderID { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }

    }
}
