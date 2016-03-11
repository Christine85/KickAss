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
			//TODO: Info from database
			categories.Add(new CategoryVM()
			{
				Name = "Pennor",
				ParentID = 0,
				CategoryID = 1
			}); categories.Add(new CategoryVM()
			{
				Name = "Blyertspennor",
				ParentID = 1,
				CategoryID = 5
			});
			categories.Add(new CategoryVM()
			{
				Name = "Tejp",
				ParentID = 0,
				CategoryID = 2
			});
			categories.Add(new CategoryVM()
			{
				Name = "Gem",
				ParentID = 0,
				CategoryID = 3
			});
			categories.Add(new CategoryVM()
			{
				Name = "Häftapparater",
				ParentID = 0,
				CategoryID = 4
			});
			categories.Add(new CategoryVM()
			{
				Name = "Bläckpennor",
				ParentID = 1,
				CategoryID = 6
			});
			categories.Add(new CategoryVM()
			{
				Name = "Dubbelhäftad tejp",
				ParentID = 2,
				CategoryID = 7
			});
			//

			var view = View();
			view.ViewData["Categories"] = categories;

			return View();
        }
        public IActionResult LogIn()
        {
			List<CategoryVM> categories = new List<CategoryVM>();
			//TODO: Info from database
			categories.Add(new CategoryVM()
			{
				Name = "Pennor",
				ParentID = 0,
				CategoryID = 1
			}); categories.Add(new CategoryVM()
			{
				Name = "Blyertspennor",
				ParentID = 1,
				CategoryID = 5
			});
			categories.Add(new CategoryVM()
			{
				Name = "Tejp",
				ParentID = 0,
				CategoryID = 2
			});
			categories.Add(new CategoryVM()
			{
				Name = "Gem",
				ParentID = 0,
				CategoryID = 3
			});
			categories.Add(new CategoryVM()
			{
				Name = "Häftapparater",
				ParentID = 0,
				CategoryID = 4
			});
			categories.Add(new CategoryVM()
			{
				Name = "Bläckpennor",
				ParentID = 1,
				CategoryID = 6
			});
			categories.Add(new CategoryVM()
			{
				Name = "Dubbelhäftad tejp",
				ParentID = 2,
				CategoryID = 7
			});
			//

			var view = View();
			view.ViewData["Categories"] = categories;
			
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
                    ModelState.AddModelError(string.Empty, "Felmeddelande, checka fel");
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.InnerException.Message);
                return View(viewModel);
            }
        }
    }
}
