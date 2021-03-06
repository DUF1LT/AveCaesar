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
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private string _login;
        private string _password;


        public AuthorizationViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            LoginCommand = new LoginCommand(_authenticationStore, this);
        }


        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand LoginCommand { get; }

        
    }
}
