using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Context;

namespace AveCaesarApp.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AveCaesarContext db = new AveCaesarContext();
        private ProductRepository _productRepository;
        private DishRepository _dishRepository;
        private OrderRepository _orderRepository;
        private UserRepository _userRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository== null)
                    _productRepository = new ProductRepository(db);
                return _productRepository;
            }
        }

        public DishRepository DishRepository
        {
            get
            {
                if (_dishRepository == null)
                    _dishRepository = new DishRepository(db);
                return _dishRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(db);
                return _orderRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        public void Save()
        {
            db.SaveChangesAsync();
        }


        public void Dispose()
        {
        }
    }
}
