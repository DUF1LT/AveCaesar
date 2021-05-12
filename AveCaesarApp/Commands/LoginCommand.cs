using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class LoginCommand : Command
    {
        private AuthenticationStore _authenticationStore;
        private AuthorizationViewModel _authorizationViewModel;
        public LoginCommand(AuthenticationStore authenticationStore, AuthorizationViewModel authorizationViewModel)
        {
            _authenticationStore = authenticationStore;
            _authorizationViewModel = authorizationViewModel;
        }
        public override bool CanExecute(object parameter) 
        {
            return (_authorizationViewModel.Login != null && _authorizationViewModel.Password != null);
        }

        public override async void Execute(object parameter)
        {
            Profile profile = await _authenticationStore.Login(_authorizationViewModel.Login, _authorizationViewModel.Password);
            if (profile != null)
            {
                _authenticationStore.CurrentProfile = profile;
                _authorizationViewModel.NavigateToHomeCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка");
            }
        }
    }
}
