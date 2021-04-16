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
    class DishesViewModel : ViewModel
    {
        public DishesViewModel(NavigationStore navigationStore)
        {
            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));

           
        }

        public ICommand NavigateToHomeCommand { get; }
    }
}
