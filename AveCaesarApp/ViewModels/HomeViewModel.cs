using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class HomeViewModel : ViewModel
    {

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateToProductCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, 
                    () => new ProductsViewModel(navigationStore));

            NavigateToAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore,
                () => new AuthorizationViewModel(navigationStore));

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore));

            NavigateToOrdersCommand =
                new NavigateCommand<OrdersViewModel>(navigationStore, 
                    () => new OrdersViewModel(navigationStore));
        }

        public ICommand NavigateToAuthorizationCommand { get; }
        public ICommand NavigateToProductCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToOrdersCommand { get; }


    }
}
