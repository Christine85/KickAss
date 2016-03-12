using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class ShoppingCartItemVM
    {
        public ListProductVM ProductInCart { get; set; }
        public int Quantity { get; set; }
        public CurrentUserVM CurrentUser { get; set; }

    }
}
