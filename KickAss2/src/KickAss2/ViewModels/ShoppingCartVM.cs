using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class ShoppingCartVM
    {
        public List<ListProductVM> ProductsInCart { get; set; }
        public CurrentUserVM CurrentUser { get; set; }
    }
}
