using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int Name { get; set; }
        public int ParentID { get; set; }
        
    }
}
