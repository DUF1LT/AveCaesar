using System.Collections.Generic;
using System.Data.Entity;
using AveCaesarApp.Context;
using AveCaesarApp.Models;

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
            return db.Dishes;
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
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
