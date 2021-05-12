using System.Collections.Generic;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class ConcreteOrderViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private Order _currentOrder;
        private Dish _selectedItem;

        public ConcreteOrderViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore ,Order currentOrder, UnitOfWorkFactory unitOfWorkFactory)
        {
            _currentOrder = currentOrder;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersCommand =
                new NavigateCommand<OrdersViewModel>(navigationStore, () => new OrdersViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

           //DeleteSelectedItem = new DeleteSelectedItemCommand<Dish>(CurrentOrder.Dishes);

            StatusViewModel = new OrderStatusViewModel();
        }

        public Order CurrentOrder
        {
            get => _currentOrder;
            set => Set(ref _currentOrder, value);
        }

        public Dish SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public OrderStatusViewModel StatusViewModel { get; set; }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }
        public ICommand DeleteSelectedItem { get; }

       
    }
}
