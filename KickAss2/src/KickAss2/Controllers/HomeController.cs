using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using KickAss2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KickAss2.Controllers
{
    public class HomeController : Controller
    {
        KickAssDataBaseContext context;

        public HomeController(KickAssDataBaseContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
			List<CategoryVM> categories = new List<CategoryVM>();

			var view = View();
			view.ViewData["Categories"] = categories;

			return View();
        }


		public IActionResult LogIn()
        {

			return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInUserVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                var dataManager = new DataManager(context);
                bool check = dataManager.LogIn(viewModel);

                if (check == true)
                {
                    return RedirectToAction(nameof(HomeController.Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fel vid inloggning, checka email eller lösenordet");
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(viewModel);
            }
        }
    }
}
