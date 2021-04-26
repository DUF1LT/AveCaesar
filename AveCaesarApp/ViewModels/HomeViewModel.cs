using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class HomeViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        public HomeViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;

            NavigateToProductCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, 
                    () => new ProductsViewModel(navigationStore, authenticationStore));

            NavigateToAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore,
                () => new AuthorizationViewModel(navigationStore, authenticationStore));

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore, authenticationStore));

            NavigateToOrdersCommand =
                new NavigateCommand<OrdersViewModel>(navigationStore, 
                    () => new OrdersViewModel(navigationStore, authenticationStore));
        }

        public ICommand NavigateToAuthorizationCommand { get; }
        public ICommand NavigateToProductCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }


    }
}
