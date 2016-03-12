using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using KickAss2.Models;
using Microsoft.AspNet.Http;

namespace KickAss2.Controllers
{
    public class OrderController : Controller
    {
        KickAssDataBaseContext context;
        static CurrentUserVM currentUser;

        public IActionResult ShoppingCart()
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

        public IActionResult OrderHistory()
        {
            return View(currentUser);
        }

    }
}
