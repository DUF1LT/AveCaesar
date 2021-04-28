using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AveCaesarApp.Context;
using AveCaesarApp.Models;

namespace AveCaesarApp.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly AveCaesarContext db;

        public UserRepository(AveCaesarContext context)
        {
            db = context;
        }
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public Task<User> GetByLogin(string login)
        {
            return db.Users.FirstOrDefaultAsync(p => p.Login == login);
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
