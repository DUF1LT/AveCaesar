using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Context;
using AveCaesarApp.Models;
using System.Data.Entity;

namespace AveCaesarApp.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly AveCaesarContext db;

        public OrderRepository(AveCaesarContext context)
        {
            db = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
