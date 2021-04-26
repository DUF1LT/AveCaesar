using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class NavigateToSelectedOrderCommand : Command 
    {
        private NavigationStore _navigationStore;
        private OrdersViewModel _ordersViewModel;
        public NavigateToSelectedOrderCommand(NavigationStore navigationStore, OrdersViewModel ordersViewModel)
        {
            _navigationStore = navigationStore;
            _ordersViewModel = ordersViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _ordersViewModel.SelectedItem != null;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Order order)
                new NavigateCommand<OrderViewModel>(_navigationStore, () => new OrderViewModel(_navigationStore, order)).Execute(null);
        }
    }
}
