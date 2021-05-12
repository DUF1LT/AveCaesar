using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class OrderViewModel : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private int _tableNumber;
        private string _note;
        private float _totalPrice;
        private IList<DishToAdd> _dishesToAdd;

        public OrderViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            int tableNumber = 1, string note = "", float totalPrice = 0, IList<DishToAdd> dishesToAdd = null)
        {
            _navigationStore = navigationStore;
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            TableNumber = tableNumber;
            Note = note;
            TotalPrice = totalPrice;
            DishesToAdd = dishesToAdd; 

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, 
                    () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersCommand = new NavigateCommand<OrdersViewModel>(navigationStore,
                () => new OrdersViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrderDishesCommand = new NavigateCommand<OrderDishesViewModel>(navigationStore, () =>
                new OrderDishesViewModel(navigationStore, authenticationStore, unitOfWorkFactory,
                    TableNumber, Note, totalPrice, DishesToAdd));

            AddOrderCommand = new 
        }

        
        public int TableNumber
        {
            get => _tableNumber;
            set => Set(ref _tableNumber, value);
        }

        public string Note
        {
            get => _note;
            set => Set(ref _note, value);
        }

        public float TotalPrice
        {
            get => _totalPrice;
            set => Set(ref _totalPrice, value);
        }

        public IList<DishToAdd> DishesToAdd
        {
            get => _dishesToAdd;
            set
            {
                Set(ref _dishesToAdd, value);
                if(DishesToAdd != null)
                    TotalPrice = DishesToAdd.Sum(p => p.Dish.Price);
            }

        }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }
        public ICommand NavigateToOrderDishesCommand { get; }
        public ICommand AddOrderCommand { get; }

    }
}
