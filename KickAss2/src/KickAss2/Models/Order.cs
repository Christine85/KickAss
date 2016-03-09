using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Order
    {
        public Order(int addressId, int customerId, int orderId, DateTime orderDate, List<Product> orderProducts)
        {
            AddressId = addressId;
            CustomerId = customerId;
            OrderId = orderId;
            OrderDate = orderDate;
            OrderProducts = orderProducts;
        }
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> OrderProducts { get; set; }
    }
}
