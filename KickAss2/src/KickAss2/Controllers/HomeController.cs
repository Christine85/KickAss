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
        
        static CurrentUserVM currentUser;

        public HomeController(KickAssDataBaseContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            string currentUserEmail = HttpContext.Session.GetString("email");
            string currentUserName = HttpContext.Session.GetString("name");
            string currentUserIsAdmin = HttpContext.Session.GetString("IsAdmin");

            if (currentUser != null)
            {
                currentUser = new CurrentUserVM
                {
                    UserName = currentUserName,
                    Email = currentUserEmail,
                    IsAdmin = currentUserIsAdmin
                };

                return View(currentUser);
            }
            else
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
                    var email = viewModel.Email;
                    currentUser = dataManager.GetUser(email);
                    HttpContext.Session.SetString("namn", currentUser.UserName);
                    HttpContext.Session.SetString("email", currentUser.Email);
                    HttpContext.Session.SetString("admin", currentUser.IsAdmin);

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

            currentUser = null;

            return RedirectToAction(nameof(HomeController.Index));
        }
        public IActionResult MyPage()
        {
            return View();
        }
    }
}
