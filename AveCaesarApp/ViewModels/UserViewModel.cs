using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class UserViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        public UserViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;


            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

        }

        public ICommand NavigateToHomeCommand { get; }
    }
}
