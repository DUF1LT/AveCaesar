using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Context;
using AveCaesarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AveCaesarApp.Repository
{
    public class ProductRepository : IRepositoryAsync<Product>
    {
        private readonly AveCaesarContext db;

        public ProductRepository(AveCaesarContext context)
        {
            db = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(p => p.ProductDishes).ThenInclude(c => c.Dish);
        }

        public async Task<Product> Get(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            Product product = db.Products.Include(p => p.ProductDishes)
                .ThenInclude(p => p.Dish)
                .ThenInclude(p => p.DishesOrders)
                .ThenInclude(p => p.Order).First(p => p.Id == id);
            if (product != null)
            {
                foreach (var productDish in product.ProductDishes)
                {
                    foreach (var dishesOrder in productDish.Dish.DishesOrders)
                    {
                        db.Orders.Remove(db.Orders.Find(dishesOrder.OrderId));
                    }
                    db.Dishes.Remove(db.Dishes.Find(productDish.DishId));
                }
                db.Products.Remove(product);
            }
        }
    }
}
