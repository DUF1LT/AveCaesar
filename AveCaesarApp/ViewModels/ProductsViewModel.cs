using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.ViewModels.Base;
using AveCaesarApp.Stores;

namespace AveCaesarApp.ViewModels
{
    class ProductsViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        private IList<Product> _productsList;

        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private Product _selectedItem;

        public ProductsViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            DeleteSelectedProductCommand = new RelayCommand(DeleteSelectedProductExecute, DeleteSelectedProductCanExecute);

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToAddProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Add, _productsList, authenticationStore, unitOfWorkFactory));

            NavigateToEditProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Edit, _productsList, authenticationStore, unitOfWorkFactory, _selectedItem),
                (parameter) => parameter != null || _authenticationStore.CurrentUser.ProfileType != ProfileType.Manager);
            
            GetAllProducts();

        }

        
        public Product SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToAddProductCommand { get; }
        public ICommand NavigateToEditProductCommand { get; }
        public ICommand DeleteSelectedProductCommand { get; }
        private bool DeleteSelectedProductCanExecute(object arg) => SelectedItem != null;

        private async void DeleteSelectedProductExecute(object obj)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.ProductRepository.Delete(SelectedItem.Id);
                await unitOfWork.SaveAsync();
            }
        }


        private void GetAllProducts()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                ProductsList = new BindingList<Product>(unitOfWork.ProductRepository.GetAll().ToList());
            }
        }
    }

   
}
