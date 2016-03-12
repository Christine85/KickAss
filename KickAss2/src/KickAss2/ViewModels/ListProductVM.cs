using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class ListProductVM
    {
        public int ProducId { get; set; }
        public int CategoryId { get; set; }

		public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int Status { get; set; }

        // Now you can store your complex objects like so:
        //var myComplexObject = new MyClass();
        //HttpContext.Session.SetObjectAsJson("Test", myComplexObject);
        // and retrieve them just as easily:

        // var myComplexObject = HttpContext.Session.GetObjectFromJson<MyClass>("Test");

    }
}
