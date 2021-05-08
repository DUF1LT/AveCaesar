using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public class ProductsDishes
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int ProductAmount { get; set; }
    }
}
