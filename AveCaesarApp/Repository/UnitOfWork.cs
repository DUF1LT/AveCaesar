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
        private readonly AveCaesarContext _dbContext;
        private ProductRepository _productRepository;
        private DishRepository _dishRepository;
        private OrderRepository _orderRepository;
        private UserRepository _userRepository;


        public UnitOfWork()
        {
            _dbContext = new AveCaesarContext();
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_dbContext);
                return _productRepository;
            }
        }

        public DishRepository DishRepository
        {
            get
            {
                if (_dishRepository == null)
                    _dishRepository = new DishRepository(_dbContext);
                return _dishRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_dbContext);
                return _orderRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
        }
    }
}
