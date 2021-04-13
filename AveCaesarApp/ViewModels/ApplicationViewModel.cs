using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class ApplicationViewModel : ViewModel
    {
        private ICommand _changeViewCommand;
        private ViewModel _currentViewModel;
        private List<ViewModel> _viewModels;

        public ApplicationViewModel()
        {
            
        }

        public List<ViewModel> ViewModels
        {
            get
            {
                if (_viewModels == null)
                    _viewModels = new List<ViewModel>();
                return _viewModels; 
            }
        }

        public ViewModel CurrentViewModel 
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel != value)
                    _currentViewModel = value;
                OnPropertyChanged();
            }
        }
    }   
}
