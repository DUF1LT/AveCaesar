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
        protected readonly NavigationStore NavigationStore;
        protected readonly Func<TViewModel> CreatedViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createdViewModel)
        {
            NavigationStore = navigationStore;
            CreatedViewModel = createdViewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            NavigationStore.CurrentViewModel = CreatedViewModel();
        }
    }
}
