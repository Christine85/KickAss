using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class SessionVM
    {
        public List<ListProductVM> ProductListVM { get; set; }
        public LogInUserVM LogInUserVM { get; set; }
        public CurrentUserVM CurrentUserVM { get; set; }


    }
}
