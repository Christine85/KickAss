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
        static int userID;

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
                user.IsAdmin = "0";

                context.Users.Add(user);
                context.SaveChanges();

                //spara id för kunden
                userID = user.UserId;

                var adress = new Address();

                adress.Street = viewModel.Street;
                adress.Zip = viewModel.Zip;
                adress.City = viewModel.City;
                adress.UserID = userID;

                context.Addresses.Add(adress);
                context.SaveChanges();

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

        public List<OrderHistoryVM> OrderHistory(CurrentUserVM currentUser)
        {
            int userIDConverted = Convert.ToInt32(currentUser.UserID);

            return context.Orders
                 .Where(o => o.UserId == userIDConverted)
                 .Select(o => new OrderHistoryVM
                 {
                     OrderDate = o.OrderDate,
                     OrderId = o.OrderId,
                     TotalPrice = o.TotalPrice,
                     CurrentUser = currentUser

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

        public List<ListProductVM> ListProducts(CurrentUserVM currentUser)
        {
            return context.Products
                .OrderBy(c => c.CategoryId)
                .Select(c => new ListProductVM
                {
                    Name = c.ProductName,
                    Description = c.Description,
                    Price = c.Price,
                    Status = c.Status,
                    CurrentUser = currentUser
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
                    Price = c.Price,
                    Status = c.Status
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

        internal List<Product> GetProductsFromCategory(int categoryID)
        {
            //om man trycker på en underkategori
            if (categoryID > 5)
            {
                return context.Products
                     .Where(o => o.CategoryId == categoryID && o.Status == 1)
                     .Select(o => new Product
                     {
                         ProductId = o.ProductId,
                         ProductName = o.ProductName,
                         Description = o.Description,
                         Price = o.Price,
                         Stock = o.Stock
                     })
                     .ToList();
            }
            else
            {
                //om man trycker på en huvudkategori plocka ut en lista av alla underkategorier
                var allProductInParentID = context.Categorys
                     .Where(o => o.ParentID == categoryID)
                     .ToList();

                List<Product> productListUnderCategory = new List<Product>();

                foreach (var v in allProductInParentID)
                {

                    productListUnderCategory.AddRange(context.Products
                    .Where(o => o.CategoryId == v.CategoryID && o.Status == 1)                    
                    .ToList());                                      
                }
                return productListUnderCategory;
            }
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
        public CurrentUserVM GetUser(string email)
        {
            return context.Users
                 .Where(o => o.Email == email)
                 .Select(o => new CurrentUserVM
                 {
                     UserName = o.FirstName,
                     Email = o.Email,
                     IsAdmin = o.IsAdmin,
                     UserID = Convert.ToString(o.UserId)

                 })
                 .Single();
        }
    }
}
