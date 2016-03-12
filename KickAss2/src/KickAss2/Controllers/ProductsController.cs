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
    public class ProductsController : Controller
    {
        KickAssDataBaseContext context;
        static CurrentUserVM currentUser;

        public ProductsController(KickAssDataBaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            string currentUserEmail = HttpContext.Session.GetString("email");
            string currentUserName = HttpContext.Session.GetString("name");
            string currentUserIsAdmin = HttpContext.Session.GetString("IsAdmin");

            if (currentUser != null)
            {
                currentUser = new CurrentUserVM
                {
                    UserName = currentUserEmail,
                    Email = currentUserEmail,
                    IsAdmin = currentUserIsAdmin
                };

                var dataManager = new DataManager(context);
                var model = dataManager.ListProducts(currentUser);

                return View(model);
            }
            else
            {
                var dataManager = new DataManager(context);
                var model = dataManager.ListProducts();
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var dataManager = new DataManager(context);
            dataManager.CreateProduct(viewModel);

            return RedirectToAction(nameof(ProductsController.Index));
        }
        public IActionResult Create()
        {
            var model = new CreateProductVM();
            model.CategoryIdList = new SelectListItem[]
                {
                    new SelectListItem { Text = "-------Välj kategori-------", Value = ""},
                    new SelectListItem { Text = "Almanackor", Value = "1"},
                    new SelectListItem { Text = "Block", Value = "2"},
                    new SelectListItem { Text = "Fästa & försluta", Value = "3"},
                    new SelectListItem { Text = "Förvaring", Value = "4"},
                    new SelectListItem { Text = "Kuvert", Value = "5"},
                    new SelectListItem { Text = "Papper", Value = "6"},
                    new SelectListItem { Text = "Pennor", Value = "7"},
                    new SelectListItem { Text = "Pärmar", Value = "8"},
                    new SelectListItem { Text = "Tejp", Value = "9"}
                };
            return View(model);
        }

        public IActionResult AddProductToCart(ListProductVM viewModel)
        {
            List<ListProductVM> shoppingCart;
            if (HttpContext.Session.GetObjectFromJson<List<ListProductVM>>("shoppingCart") == null)
            {
                shoppingCart = new List<ListProductVM>();
                shoppingCart.Add(viewModel);
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
                return RedirectToAction(nameof(ProductsController.Index));
            }
            shoppingCart = HttpContext.Session.GetObjectFromJson<List<ListProductVM>>("shoppingCart");
            shoppingCart.Add(viewModel);
            HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
            
            return RedirectToAction(nameof(ProductsController.Index));
        }
    }
}
