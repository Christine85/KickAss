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

        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
