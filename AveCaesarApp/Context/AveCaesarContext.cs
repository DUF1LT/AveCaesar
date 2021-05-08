using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AveCaesarApp.Context
{
    public class AveCaesarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-M3AOJU2;Initial Catalog=Ave_CaesarDB;Integrated Security=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductsDishes>()
                .HasKey(t => new {t.ProductId, t.DishId});

            modelBuilder
                .Entity<ProductsDishes>()
                .HasOne(pr => pr.Product)
                .WithMany(s => s.ProductDishes)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder
                .Entity<ProductsDishes>()
                .HasOne(pr => pr.Dish)
                .WithMany(s => s.ProductsDishes)
                .HasForeignKey(pr => pr.DishId);


            modelBuilder
                .Entity<DishesOrders>()
                .HasKey(t => new { t.DishId, t.OrderId });

            modelBuilder
                .Entity<DishesOrders>()
                .HasOne(pr => pr.Dish)
                .WithMany(s => s.DishesOrders)
                .HasForeignKey(pr => pr.DishId);

            modelBuilder
                .Entity<DishesOrders>()
                .HasOne(pr => pr.Order)
                .WithMany(s => s.DishesOrders)
                .HasForeignKey(pr => pr.OrderId);

        }
    }
}
