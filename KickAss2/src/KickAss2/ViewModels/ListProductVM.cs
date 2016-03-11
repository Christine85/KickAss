using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class ListProductVM
    {
		public int CategoryId { get; set; }

		public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

       // Now you can store your complex objects like so:
        //var myComplexObject = new MyClass();
        //HttpContext.Session.SetObjectAsJson("Test", myComplexObject);
       // and retrieve them just as easily:

       // var myComplexObject = HttpContext.Session.GetObjectFromJson<MyClass>("Test");

    }
}
