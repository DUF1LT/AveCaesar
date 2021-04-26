using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AveCaesarApp.Context
{
    class ProductContext : DbContext
    {
        public ProductContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
