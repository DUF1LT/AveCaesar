using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class HomeViewModel : ViewModel
    {
        public ICommand NavigateToProductCommand { get; }
        public ICommand NavigateToAuthorizationCommand { get; }


        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateToProductCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, () => new ProductsViewModel(navigationStore));

            NavigateToAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore,
                () => new AuthorizationViewModel(navigationStore));
        }
    }
}
