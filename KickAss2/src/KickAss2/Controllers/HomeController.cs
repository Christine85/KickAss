using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using KickAss2.Models;
using Microsoft.AspNet.Http;

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
            string currentUser = HttpContext.Session.GetString("email");
            if (currentUser != null)
            {
                return View(new CurrentUserVM{
                    UserName = currentUser
                });
            }            

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
                    var currentUser = dataManager.GetUser(viewModel.Email);
                    HttpContext.Session.SetString("namn", currentUser[0].UserName);
                    HttpContext.Session.SetString("email", currentUser[1].Email);
                    HttpContext.Session.SetString("admin", currentUser[2].IsAdmin.ToString());

                    return RedirectToAction(nameof(HomeController.Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fel vid inloggning, checka email eller lösenordet");
                    return View();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(viewModel);
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
