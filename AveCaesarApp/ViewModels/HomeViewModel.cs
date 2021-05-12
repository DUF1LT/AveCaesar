using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Services;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class HomeViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public HomeViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToProductCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, 
                    () => new ProductsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore,
                () => new AuthorizationViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersCommand =
                new NavigateCommand<OrdersViewModel>(navigationStore, 
                    () => new OrdersViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToUsersCommand = new NavigateCommand<UsersViewModel>(navigationStore,
                () => new UsersViewModel(navigationStore, _authenticationStore, _unitOfWorkFactory),
                (param) => AccessService.CanProfileAccessUsers(_authenticationStore.CurrentProfile));
        }

        public ICommand NavigateToAuthorizationCommand { get; }
        public ICommand NavigateToProductCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }
        public ICommand NavigateToUsersCommand { get; }


        public AuthenticationStore AuthenticationStore => _authenticationStore;
    }
}
