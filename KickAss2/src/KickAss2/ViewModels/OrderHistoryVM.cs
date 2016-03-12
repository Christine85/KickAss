using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class OrderHistoryVM
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public CurrentUserVM CurrentUser { get; set; }
    }
}