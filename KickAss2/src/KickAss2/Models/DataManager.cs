using KickAss2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace KickAss2.Models
{
    public class DataManager
    {
        KickAssDataBaseContext context;
        static int UserID;

        public DataManager(KickAssDataBaseContext context)
        {
            this.context = context;
        }

        public bool CreateUser(CreateUserVM viewModel)
        {
            var user = new User();

            //kolla hur många som finns med samma email
            var result = context.Users.Count(o => o.Email.Equals(viewModel.Email));

            if (result == 0)
            {
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.PhoneNumber = viewModel.PhoneNumber;

                context.Users.Add(user);
                context.SaveChanges();

                //sparar ID för den nya användaren
                UserID = user.UserId;

                var security = new Security();

                security.Email = viewModel.Email;
                security.Password = viewModel.Password;

                context.Securitys.Add(security);
                context.SaveChanges();

                //true om kund lagts till i DB
                return true;

            }

            else
            {
                //false om email redan fanns i DB
                return false;
            }
        }

        public List<OrderHistoryVM> OrderHistory(OrderHistoryVM viewModel)
        {
            return context.Orders
                 .Where(o => o.UserId == UserID)
                 .Select(o => new OrderHistoryVM
                 {
                     OrderDate = o.OrderDate,
                     OrderId = o.OrderId,
                     TotalPrice = o.TotalPrice
                 })
                 .ToList();
        }
        public List<ProductInOrderVM> OrderDetails(int orderID)
        {
            return context.ProductsInOrder
                .Where(o => o.OrderID == orderID)
                .Select(o => new ProductInOrderVM
                {
                    ProductID = o.ProductId,
                    ProductName = o.ProductName,
                    Quantity = o.Quantity,
                    Price = o.Price
                })
                .ToList();
        }

        public List<ListProductVM> ListProducts()
        {
            return context.Products
                .OrderBy(c => c.CategoryId)
                .Select(c => new ListProductVM
                {
                    Name = c.ProductName,
                    Description = c.Description,
                    Price = c.Price
                })
                .ToList();
        }
        public void CreateProduct(CreateProductVM viewModel)
        {
            var product = new Product();

            product.ProductName = viewModel.Name;
            product.Description = viewModel.Description;
            product.Price = viewModel.Price;
            product.Stock = viewModel.Stock;
            product.CategoryId = viewModel.SelectedCategoryId;

            context.Products.Add(product);
            context.SaveChanges();
        }

        public bool LogIn(LogInUserVM viewModel)
        {
            var check = context.Securitys.Any(o => o.Email.Equals(viewModel.Email) && o.Password.Equals(viewModel.Password));

            if (check)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public CurrentUserVM[] GetUser(string email)
        {
            return context.Users
                 .Where(o => o.Email == email)
                 .Select(o => new CurrentUserVM
                 {
                     UserName = o.FirstName,
                     Email = o.Email,
                     IsAdmin = o.IsAdmin
                     
                 })
                 .ToArray();
        }
    }
}
