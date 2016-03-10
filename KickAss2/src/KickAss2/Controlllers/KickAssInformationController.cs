using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;

namespace KickAss2.Controlllers
{
    public class KickAssInformationController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult GetInTouch()
        {
            return View();
        }
    }
}
