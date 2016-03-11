using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using KickAss2.Models;
using KickAss2.Controllers;

namespace KickAss2.Controlllers
{
    public class UserController : Controller
    {
        KickAssDataBaseContext context;

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
                    //return RedirectToAction(nameof(HomeController.LogIn));
                    return RedirectToAction(nameof(HomeController.LogIn));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Mailadressen finns redan registrerad som kund");
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(viewModel);
            }
        }
        //public IActionResult CheckOrderHistory(OrderHistoryVM viewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(viewModel);

        //    try
        //    {
        //        var dataManager = new DataManager(context);
        //        bool check = dataManager.CreateUser(viewModel);

        //        if (check == true)
        //        {
        //            return RedirectToAction(nameof(HomeController.LogIn));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Mailadressen finns redan registrerad som kund");
        //            return View(viewModel);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError(string.Empty, e.Message);
        //        return View(viewModel);
        //    }
        //}
    }
}
