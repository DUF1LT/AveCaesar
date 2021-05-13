using System.Collections.Generic;
using System.Linq;
using AveCaesarApp.Context;
using AveCaesarApp.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace AveCaesarApp.Repository
{
    public class DishRepository : IRepository<Dish>
    {
        private readonly AveCaesarContext db;

        public DishRepository(AveCaesarContext context)
        {
            db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes
                .Include(p => p.DishesOrders)
                .ThenInclude(c => c.Order)
                .Include(d => d.ProductsDishes)
                .ThenInclude(t => t.Product);
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Create(Dish item)
        {
            db.Dishes.Add(item);
        }

        public void Update(Dish item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes
                .Include(p => p.DishesOrders)
                .ThenInclude(p => p.Order)
                .First(p => p.Id == id);
            if (dish != null)
            {
                foreach (var dishesOrder in dish.DishesOrders)
                {
                    db.Orders.Remove(db.Orders.Find(dishesOrder.OrderId));
                }
                db.Dishes.Remove(dish);
            }
        }
    }
}
