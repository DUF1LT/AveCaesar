using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Services;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class OrdersViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<Order> _ordersList;

        private Order _selectedItem;

        public OrdersViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;


            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore,
                    () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToSelectedOrderCommand = new NavigateToSelectedOrderCommand(navigationStore,_authenticationStore,  this, _unitOfWorkFactory);

            NavigateToOrderCommand = new NavigateCommand<OrderViewModel>(navigationStore,
                () => new OrderViewModel(navigationStore, authenticationStore, unitOfWorkFactory), 
                (parameter) => AccessService.CanProfileAccessOrder(_authenticationStore.CurrentProfile) );

            DeleteSelectedItem = new RelayCommand(DeleteSelectedItemExecute, DeleteSelectedItemCanExecute);

            LoadOrders();
        }

        public IList<Order> OrdersList
        {
            get => _ordersList;
            set => Set(ref _ordersList, value);
        }

        public Order SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToOrderCommand { get; }
        public ICommand NavigateToSelectedOrderCommand { get; }
        public ICommand DeleteSelectedItem { get; }

        private bool DeleteSelectedItemCanExecute(object arg)
        {
            if(SelectedItem == null)
            {
                MessageBox.Show("Ни один заказ не выбран", "Ошибка");
                return false;
            }    
            return SelectedItem != null && AccessService.CanProfileAccessOrder(_authenticationStore.CurrentProfile)
                                        && MessageBox.Show("Вы действительно хотите удалить заказ?", "Предупреждение",
                                            MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        private async void DeleteSelectedItemExecute(object obj)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.OrderRepository.Delete(unitOfWork.OrderRepository.Get(SelectedItem.Id).Id);
;               await unitOfWork.SaveAsync();
                OrdersList = unitOfWork.OrderRepository.GetAll().ToList();

            }
        }

        private void LoadOrders()
        {
            using (var context = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if (_authenticationStore.CurrentProfile.ProfileType == FullProfileType.Waiter ||
                    _authenticationStore.CurrentProfile.ProfileType == FullProfileType.Admin)
                {
                    OrdersList = context.OrderRepository.GetAll()
                        .Where(p => p.WaiterName == _authenticationStore.CurrentProfile.FullName && p.Status != FullOrderStatus.Finished)
                        .OrderByDescending(p => p.Status).ToList();
                    OrdersList = new List<Order>(OrdersList.Concat(context.OrderRepository.GetAll()
                        .Where(p => p.WaiterName == _authenticationStore.CurrentProfile.FullName &&
                                    p.Status == FullOrderStatus.Finished)
                        .OrderByDescending(p => p.AcceptedTime)
                        .ToList()));
                }
                else
                {
                    OrdersList = context.OrderRepository.GetAll()
                        .Where(p => p.Status != FullOrderStatus.Finished)
                        .OrderByDescending(p => p.Status).ToList();

                    OrdersList = new List<Order>(OrdersList.Concat(context.OrderRepository.GetAll()
                        .Where(p => p.Status == FullOrderStatus.Finished)
                        .OrderByDescending(p => p.AcceptedTime)
                        .ToList()));
                }

            }
        }
    }
}
