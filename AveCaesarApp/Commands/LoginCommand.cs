using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
