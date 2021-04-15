using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.Commands
{
    class NavigateCommand<TViewModel> : Command
        where TViewModel : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createdViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createdViewModel)
        {
            _navigationStore = navigationStore;
            _createdViewModel = createdViewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createdViewModel();
        }
    }
}
