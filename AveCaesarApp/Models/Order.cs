using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AveCaesarApp.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        Accepted = 1,
        [Display(Name = "Готовится")]
        InProgress = 2,
        [Display(Name = "Готов")]
        Ready = 3
    }
    public class Order : Item
    {
        public Order()
        {
            
        }
        public Order(int id, int tableNumber, BindingList<Dish> dishes, DateTime acceptedTime, DateTime preparedTime, OrderStatus status, string note) : base(id)
        {
            TableNumber = tableNumber;
            AcceptedTime = acceptedTime;
            PreparedTime = preparedTime;
            Status = status;
            TotalPrice = dishes.Sum(el => el.Price);
            Note = note;
        }


        public string WaiterName { get; set; }
        public int TableNumber { get; set; }
        public DateTime AcceptedTime { get; set; }  
        public DateTime PreparedTime { get; set; }
        public OrderStatus Status { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public IList<DishesOrders> DishesOrders { get; set; }

    }
}
