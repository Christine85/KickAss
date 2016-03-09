using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Customer : User
    {
        public Customer(int userID, string firstName, string lastName, string email, string phoneNumber, List<Address> addresses, List<Product> shoppingCart, List<Order> orderHistory) : base(userID, firstName, lastName, email)
        {
            PhoneNumber = phoneNumber;
            Addresses = addresses;
            ShoppingCart = shoppingCart;
            OrderHistory = orderHistory;
        }

        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Product> ShoppingCart { get; set; }
        public List<Order> OrderHistory { get; set; }
    }
}
