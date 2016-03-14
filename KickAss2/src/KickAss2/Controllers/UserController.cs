using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using KickAss2.Models;
using KickAss2.Controllers;
using Microsoft.AspNet.Http;

namespace KickAss2.Controlllers
{
    public class UserController : Controller
    {
        KickAssDataBaseContext context;
        static CurrentUserVM currentUser;

        public UserController(KickAssDataBaseContext context)
        {
            this.context = context;
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                var dataManager = new DataManager(context);
                bool check = dataManager.CreateUser(viewModel);

                if (check == true)
                {
                    return RedirectToAction(nameof(HomeController.LogIn));
                    //return RedirectToAction(nameof(HomeController.LogIn));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Mailadressen finns redan registrerad som kund");
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.InnerException.Message);
                return View(viewModel);
            }
        }
        public IActionResult CheckOrderHistory(OrderHistoryVM viewModel)
        {
            string currentUserEmail = HttpContext.Session.GetString("email");
            string currentUserName = HttpContext.Session.GetString("name");
            string currentUserIsAdmin = HttpContext.Session.GetString("IsAdmin");

            if (currentUserEmail != null)
            {
                currentUser = new CurrentUserVM
                {
                    UserName = currentUserName,
                    Email = currentUserEmail,
                    IsAdmin = currentUserIsAdmin
                };


                if (!ModelState.IsValid)
                    return View(viewModel);

                try
                {
                    var dataManager = new DataManager(context);
                    var orderHistory = dataManager.OrderHistory(currentUser);

                    if (orderHistory.Count > 0)
                    {
                        return View(orderHistory);
                    }
                    else
                    {                        
                        return View(currentUser);
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View();
                }
            }
            else
                return View();
        }

        public IActionResult CheckOrderDetail(int orderID)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var dataManager = new DataManager(context);
                var orderDetails = dataManager.OrderDetails(orderID);

                return View(orderDetails);
                
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
    }
}
