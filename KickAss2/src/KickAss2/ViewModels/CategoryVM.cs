using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int ParentID { get; set; }
        public CurrentUserVM CurrentUser { get; set; }
    }
}
