using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class ApplicationViewModel : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private string _title = "Ave Caesar";
        private ImageSource _windowIcon = new BitmapImage(new Uri(@"pack://application:,,,/Images/LogoIcon.png"));

        public ApplicationViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }


        public ViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public ImageSource WindowIcon
        {
            get => _windowIcon;
            set => Set(ref _windowIcon, value);
        }
       
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
