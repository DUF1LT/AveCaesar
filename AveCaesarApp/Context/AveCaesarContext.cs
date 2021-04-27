using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using System.Data.Entity;

namespace AveCaesarApp.Context
{
    public class AveCaesarContext : DbContext
    {
        public AveCaesarContext() : base("DbConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
