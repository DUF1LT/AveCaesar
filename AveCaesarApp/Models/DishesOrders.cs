using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public class DishesOrders
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishAmount { get; set; }
    }
}
