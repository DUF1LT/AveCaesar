using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.ViewModels.Base;
using AveCaesarApp.Stores;
using System;
using System.Text.RegularExpressions;

namespace AveCaesarApp.ViewModels
{
    class ProductsViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;

        private IList<Product> _productsList;

        private IList<Product> _defaultList;

        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private Product _selectedItem;

        private string _searchExpression;

        public ProductsViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            DeleteSelectedProductCommand = new RelayCommand(DeleteSelectedProductExecute, 
                DeleteSelectedProductCanExecute);

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToAddProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Add, _productsList, authenticationStore, unitOfWorkFactory));

            NavigateToEditProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Edit, _productsList, authenticationStore, unitOfWorkFactory, _selectedItem),
                (parameter) => parameter != null || _authenticationStore.CurrentUser.ProfileType != ProfileType.Manager);

            SearchProductsByExpressionCommand = new RelayCommand(SearchProductsByExpressionCommandExecute,
                SearchProductsByExpressionCommandCanExecute);


            GetAllProducts();

        }


        public Product SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<Product> DefaultList
        {
            get => _defaultList;
            set => Set(ref _defaultList, value);
        }

        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }

        public string SearchExpression
        {
            get => _searchExpression;
            set => Set(ref _searchExpression, value);
        }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToAddProductCommand { get; }
        public ICommand NavigateToEditProductCommand { get; }
        public ICommand DeleteSelectedProductCommand { get; }

        private bool DeleteSelectedProductCanExecute(object arg) =>
            SelectedItem != null && MessageBox.Show("Вы точно хотите удалить данные?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        private async void DeleteSelectedProductExecute(object obj)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.ProductRepository.Delete(SelectedItem.Id);
                ProductsList.Remove(SelectedItem);
                await unitOfWork.SaveAsync();
            }
        }
        public ICommand SearchProductsByExpressionCommand{ get; }

        private bool SearchProductsByExpressionCommandCanExecute(object arg) => true;

        private void SearchProductsByExpressionCommandExecute(object obj)
        {
            if (SearchExpression == string.Empty)
                ProductsList = DefaultList;
            else
            {
                Regex regex = new Regex($"^{SearchExpression.ToLower()}");
                ProductsList = DefaultList.Where(p => regex.IsMatch(p.Name.ToLower())).ToList();
            }

        }


        private void GetAllProducts()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
               ProductsList = DefaultList = new BindingList<Product>(unitOfWork.ProductRepository.GetAll().ToList());
            }
        }
    }

   
}
