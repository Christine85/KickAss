using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KickAss2.Models
{
    public class Product
    {
        public Product(int productId, string name, int stock, string description, float price, int categoryId)
        {
            ProductId = productId;
            Name = name;
            Stock = stock;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        //public Image ProductImage { get; set; }
    }
}
