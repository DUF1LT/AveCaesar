using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class UsersViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        private IList<User> _usersList;

        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private User _selectedItem;

        public UsersViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            DeleteSelectedUserCommand = new RelayCommand(DeleteSelectedUserExecute, DeleteSelectedUserCanExecute);

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToUserCommand = new NavigateCommand<UserViewModel>(navigationStore, () => new UserViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            GetAllUsers();

        }
        public ICommand DeleteSelectedUserCommand { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToUserCommand { get; }


        public User SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<User> UsersList
        {
            get => _usersList;
            set => Set(ref _usersList, value);
        }

        private bool DeleteSelectedUserCanExecute(object arg) => SelectedItem != null && MessageBox
            .Show("Вы действительно хотите удалить пользователя?", "Предупреждение",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        private async void DeleteSelectedUserExecute(object obj)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.UserRepository.Delete(SelectedItem.Id);
                await unitOfWork.SaveAsync();
                GetAllUsers();
            }
        }

        private void GetAllUsers()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                UsersList = new BindingList<User>(unitOfWork.UserRepository.GetAll().ToList());
            }
        }
    }

}
