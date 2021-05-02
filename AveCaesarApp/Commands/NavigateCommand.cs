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
        protected readonly Func<object, bool> CanNavigateExecute;


        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createdViewModel, Func<object,bool> canExecute = null)
        {
            NavigationStore = navigationStore;
            CreatedViewModel = createdViewModel;
            CanNavigateExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return CanNavigateExecute == null || CanNavigateExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            NavigationStore.CurrentViewModel = CreatedViewModel();
        }
    }
}
