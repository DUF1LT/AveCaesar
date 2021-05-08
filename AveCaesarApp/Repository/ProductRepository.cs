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

        public async void Delete(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}
