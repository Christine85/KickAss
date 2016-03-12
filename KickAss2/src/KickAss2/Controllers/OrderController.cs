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
            var dataManager = new DataManager(context);
            ShoppingCartVM shoppingCart = new ShoppingCartVM();
            string currentUserEmail = HttpContext.Session.GetString("email");
            string currentUserName = HttpContext.Session.GetString("name");
            string currentUserIsAdmin = HttpContext.Session.GetString("IsAdmin");
            if (currentUserEmail != null)
            {
                currentUser = new CurrentUserVM
                {
                    UserName = currentUserEmail,
                    Email = currentUserEmail,
                    IsAdmin = currentUserIsAdmin
                };
                shoppingCart.CurrentUser = currentUser;
                //return View(currentUser);
            }
            else
            {
                shoppingCart.CurrentUser = null;
            }

            if (HttpContext.Session.GetObjectFromJson<List<ListProductVM>>("shoppingCart") == null)
            {
                return View(shoppingCart);
            }
            else
            {
                List<ListProductVM> items = HttpContext.Session.GetObjectFromJson<List<ListProductVM>>("shoppingCart");
                var result = items.GroupBy(i => i.ProducId);
                shoppingCart.ShoppingList = new List<ShoppingCartItemVM>();
                foreach (var group in result)
                {
                    shoppingCart.ShoppingList.Add(new ShoppingCartItemVM { ProductInCart = group.First(), Quantity = group.Count(), CurrentUser = currentUser });
                }
                var model = shoppingCart;
                return View(model);
            }
        }
    }
}
