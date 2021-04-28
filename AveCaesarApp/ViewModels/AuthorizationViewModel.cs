using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class AuthorizationViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWork _unitOfWork;

        public AuthorizationViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWork unitOfWork)
        {
            _authenticationStore = authenticationStore;
            _unitOfWork = unitOfWork;
            _unitOfWork.UserRepository.

            NavigateToHomeCommand=
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore));
        }

        public ICommand NavigateToHomeCommand { get; }


    }
}
