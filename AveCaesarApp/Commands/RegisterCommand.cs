using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    public class RegisterCommand : Command
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UserViewModel _userViewModel;
        private readonly ICommand _navigateToUsers;

        public RegisterCommand(AuthenticationStore authenticationStore, UserViewModel userViewModel, ICommand navigateToUsers)
        {
            _authenticationStore = authenticationStore;
            _userViewModel = userViewModel;
            _navigateToUsers = navigateToUsers;
        }

        public override bool CanExecute(object parameter)
        {
            return (_userViewModel.Login != string.Empty
                    && _userViewModel.Password != string.Empty
                    && _userViewModel.FullName != string.Empty
                    && _userViewModel.ConfirmPassword != string.Empty);
        }

        public override async void Execute(object parameter)
        {
            await _authenticationStore.Register(_userViewModel.Login, _userViewModel.Password, _userViewModel.ConfirmPassword,
                _userViewModel.FullName, _userViewModel.ProfileType);
            _navigateToUsers.Execute(null);
        }
    }
}
