using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public class UserViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _fullName;
        private string _login;
        private string _password;
        private string _confirmPassword;
        private ProfileType _profileType;

        public UserViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            ProfileTypeViewModel = new EnumMenuViewModel<ProfileType>();
            ProfileType = ProfileType.Manager;
            ProfileTypeViewModel.OnSelectionChanged += () => ProfileType = ProfileTypeViewModel.SelectedItem;

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToUsersCommand = new NavigateCommand<UsersViewModel>(navigationStore,
                () => new UsersViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            RegisterUserCommand = new RegisterCommand(authenticationStore, this, NavigateToUsersCommand);

        }

        public string FullName
        {
            get => _fullName;
            set => Set(ref _fullName, value);
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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => Set(ref _confirmPassword, value);
        }
        public ProfileType ProfileType
        {
            get => _profileType;
            set => Set(ref _profileType, value);
        }
        public EnumMenuViewModel<ProfileType> ProfileTypeViewModel { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToUsersCommand { get; }
        public ICommand RegisterUserCommand { get; }

       
    }
}
