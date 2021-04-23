using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class OrderStatusViewModel : ViewModel
    {
        private IList<OrderStatus> _items;
        private OrderStatus _selectedItem;
        public event Action OnSelectionChanged;

        public IList<OrderStatus> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public OrderStatus SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnSelectionChanged?.Invoke();
            }
        }

        public OrderStatusViewModel()
        {
            Items = Enum.GetValues<OrderStatus>().ToList();
        }
    }
}
