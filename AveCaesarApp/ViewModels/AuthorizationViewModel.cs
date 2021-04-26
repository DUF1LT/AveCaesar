using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class AuthorizationViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        public AuthorizationViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;

            NavigateToHomeCommand=
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore));
        }

        public ICommand NavigateToHomeCommand { get; }


    }
}
