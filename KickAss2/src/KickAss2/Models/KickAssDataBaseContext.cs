using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class KickAssDataBaseContext : DbContext
    {
        //DB
        public DbSet<User> Users { get; set; }
        public DbSet <Address> Addresses { get; set; }
        public DbSet<Security> Securitys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInOrder> ProductsInOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Security>().ToTable("Securitys");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<ProductInOrder>().ToTable("ProductsInOrder");
        }
    }
}
