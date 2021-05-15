using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AveCaesarApp.Extensions;
using AveCaesarApp.Models;
using AveCaesarApp.Services;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;
using Org.BouncyCastle.Crypto.Engines;

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
            return !string.IsNullOrEmpty(_userViewModel.Login) 
                   && !string.IsNullOrEmpty(_userViewModel.Password)
                   && !string.IsNullOrEmpty(_userViewModel.FullName) 
                   && !string.IsNullOrEmpty(_userViewModel.ConfirmPassword);
        }

        public override async void Execute(object parameter)
        {
          RegistrationResult result = await _authenticationStore.Register(_userViewModel.Login, _userViewModel.Password, _userViewModel.ConfirmPassword,
                _userViewModel.FullName, (FullProfileType)_userViewModel.ProfileType);
          if(result == RegistrationResult.Success)
            _navigateToUsers.Execute(null);
          else
          {
              MessageBox.Show($"{result.GetDisplayName()}", "Ошибка");
          }
        }
    }
}
