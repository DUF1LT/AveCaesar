using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class AuthorizationViewModel : ViewModel
    {
        public ICommand NavigateCommand { get; }

        public AuthorizationViewModel(NavigationStore navigationStore)
        {
            NavigateCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }
    
    }
}
