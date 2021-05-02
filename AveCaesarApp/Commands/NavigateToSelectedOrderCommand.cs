using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class NavigateToSelectedOrderCommand : Command 
    {
        private NavigationStore _navigationStore;
        private OrdersViewModel _ordersViewModel;
        private AuthenticationStore _authenticationStore;
        private UnitOfWorkFactory _unitOfWorkFactory;
        public NavigateToSelectedOrderCommand(
            NavigationStore navigationStore, 
            AuthenticationStore authenticationStore ,
            OrdersViewModel ordersViewModel, 
            UnitOfWorkFactory unitOfWorkFactory)
        {
            _navigationStore = navigationStore;
            _ordersViewModel = ordersViewModel;
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public override bool CanExecute(object parameter)
        {
            return _ordersViewModel.SelectedItem != null;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Order order)
                new NavigateCommand<OrderViewModel>(_navigationStore, () => new OrderViewModel(_navigationStore, _authenticationStore, order, _unitOfWorkFactory)).Execute(null);
        }
    }
}
