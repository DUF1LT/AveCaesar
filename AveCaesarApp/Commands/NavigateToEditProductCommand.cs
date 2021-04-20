using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.Commands
{
    class NavigateToEditProductCommand<TViewModel> : NavigateCommand<TViewModel>
        where TViewModel : ViewModel
    {
        public NavigateToEditProductCommand(NavigationStore navigationStore, Func<TViewModel> createdViewModel) : base(navigationStore, createdViewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;
            return true;
        }


        public override void Execute(object parameter)
        {
            NavigationStore.CurrentViewModel = CreatedViewModel();
        }
    }
}
