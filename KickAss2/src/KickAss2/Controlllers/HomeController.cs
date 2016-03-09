using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KickAss2.Controlllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateProductVM();
            model.CategoryIdList = new SelectListItem[]
                {
                    new SelectListItem { Text = "Pennor", Value = "1"},
                    new SelectListItem { Text = "Papper", Value = "2"},
                    new SelectListItem { Text = "Förvaring", Value = "3"}
                };
            return View(model);
        }

    }
}
