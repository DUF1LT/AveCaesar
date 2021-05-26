using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using AveCaesarApp.Annotations;

namespace AveCaesarApp.Models
{
    public enum FullOrderStatus
    {
        [Display(Name = "Принят")]
        Accepted = 1,
        [Display(Name = "Готовится")]
        InProgress = 2,
        [Display(Name = "Готов")]
        Ready = 3,
        [Display(Name = "Завершён")]
        Finished = 4
    }
    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        Accepted = 1,
        [Display(Name = "Готовится")]
        InProgress = 2,
        [Display(Name = "Готов")]
        Ready = 3
    }
    public class Order : Item, INotifyPropertyChanged
    {
        private FullOrderStatus _status;
        public string WaiterName { get; set; }
        public string ChefName { get; set; }

        public int TableNumber { get; set; }
        public DateTime AcceptedTime { get; set; }
        public DateTime PreparedTime { get; set; }

        public FullOrderStatus Status
        {
            get => _status;
            set
            {
                if (value != FullOrderStatus.Ready && _status == FullOrderStatus.Ready)
                {
                    PreparedTime = default;
                    OnPropertyChanged("PreparedTime");
                }

                if (value == FullOrderStatus.Ready)
                {
                    PreparedTime = DateTime.Now;
                    OnPropertyChanged("PreparedTime");
                }
                _status = value;
            }
        }

        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public IList<DishesOrders> DishesOrders { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));}
        }
    }
}
