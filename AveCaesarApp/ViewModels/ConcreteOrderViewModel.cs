using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Services;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class ConcreteOrderViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        public AuthenticationStore authenticationStore;
        private Order _currentOrder;
        private DishToAdd _selectedItem;

        public ConcreteOrderViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore ,Order currentOrder, UnitOfWorkFactory unitOfWorkFactory)
        {
            this.authenticationStore = authenticationStore;
            _currentOrder = currentOrder;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersCommand =
                new NavigateCommand<OrdersViewModel>(navigationStore, () => new OrdersViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            DeleteSelectedDish = new RelayCommand(DeleteSelectedDishExecute, DeleteSelectedDishCanExecute);

            PrintBillCommand = new PrintBillCommand(this);

            StatusViewModel = new EnumMenuViewModel<OrderStatus>();
            StatusViewModel.SelectedItem = CurrentOrder.Status;
            StatusViewModel.OnSelectionChanged += StatusViewModelOnOnSelectionChanged;

            ProfileType = this.authenticationStore.CurrentProfile.ProfileType;

        }

        public Order CurrentOrder
        {
            get => _currentOrder;
            set => Set(ref _currentOrder, value);
        }

        public DishToAdd SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public FullProfileType ProfileType { get; }
        public EnumMenuViewModel<OrderStatus> StatusViewModel { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }
        public ICommand DeleteSelectedDish { get; }
        public ICommand PrintBillCommand { get; }


        private bool DeleteSelectedDishCanExecute(object arg) => SelectedItem != null && AccessService.CanProfileAccessOrder(authenticationStore.CurrentProfile)
            && MessageBox.Show("Вы действительно хотите удалить выбранное блюдо из заказа?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        
        private async void DeleteSelectedDishExecute(object obj)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var order = unitOfWork.OrderRepository.Get(CurrentOrder.Id);
                order.DishesOrders.Remove(order.DishesOrders.First(p => p.DishId == SelectedItem.Dish.Id));
                order.TotalPrice = order.DishesOrders.Sum(p => p.DishAmount * p.Dish.Price);
                CurrentOrder = order;
                if (order.DishesOrders.Count == 0)
                {
                    unitOfWork.OrderRepository.Delete(order.Id);
                    await unitOfWork.SaveAsync();
                    NavigateToOrdersCommand.Execute(null);
                }
                await unitOfWork.SaveAsync();

            }
        }


        private async void StatusViewModelOnOnSelectionChanged()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var currentOrder = unitOfWork.OrderRepository.Get(CurrentOrder.Id);
                CurrentOrder.Status = currentOrder.Status = StatusViewModel.SelectedItem;
                if (authenticationStore.CurrentProfile.ProfileType == FullProfileType.Chef)
                    CurrentOrder.ChefName = currentOrder.ChefName = authenticationStore.CurrentProfile.FullName;
                unitOfWork.OrderRepository.Update(currentOrder);
                await unitOfWork.SaveAsync();
            }
        }

    }
}
