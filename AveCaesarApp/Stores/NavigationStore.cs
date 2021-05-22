using System;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        private ViewModel _currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        } 
    }
}
