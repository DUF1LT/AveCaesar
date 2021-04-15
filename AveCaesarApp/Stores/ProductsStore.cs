using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;

namespace AveCaesarApp.Stores
{
    public class ProductsStore
    {
        public event Action<Product> ProductAdded;

        public void AddProduct(Product product)
        {
            ProductAdded?.Invoke(product);
        }

    }
}
