using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AveCaesarApp.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        Accepted,
        [Display(Name = "Готовится")]
        InProgress,
        [Display(Name = "Готов")]
        Ready
    }
    public class Order : Item
    {
        
        public Order(int id, string waiterName, int tableNumber, BindingList<Dish> dishes,  DateTime acceptedTime, DateTime preparedTime, OrderStatus status, string note) : base(id)
        {
            WaiterName = waiterName;
            TableNumber = tableNumber;
            Dishes = dishes;
            AcceptedTime = acceptedTime;
            PreparedTime = preparedTime;
            Status = status;
            TotalPrice = dishes.Sum(el => el.Price);
            Note = note;
        }

        public string WaiterName { get; set; }
        public int TableNumber { get; set; }
        public BindingList<Dish> Dishes { get; set; }
        public DateTime AcceptedTime { get; set; }
        public DateTime PreparedTime { get; set; }
        public OrderStatus Status { get; set; }
        public float TotalPrice { get; }
        public string Note { get; set; }

    }
}
