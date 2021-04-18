using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class AuthorizationViewModel : ViewModel
    {
        public ICommand NavigateToHomeCommand { get; }

        public AuthorizationViewModel(NavigationStore navigationStore)
        {
            NavigateToHomeCommand=
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }
    
    }
}
