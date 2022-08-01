using Microsoft.EntityFrameworkCore;
using Online_platform_for_vegetables.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Vegetable> Vegetables { get; set;  }
        public DbSet<VegetableStock> VegetableStocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set;  }
        public DbSet<Delivery> Deliveries { get; set; }
        
        

    }
}
