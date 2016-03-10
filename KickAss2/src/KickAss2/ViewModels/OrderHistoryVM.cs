using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{

    // bara för uppdateringen, ta bort!

    public class OrderHistoryVM
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Orderdatum")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Summa")]
        public float TotalPrice { get; set; }
    }
}