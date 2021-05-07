using System;
using System.Collections.Generic;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public enum ProductOperationType
    {
        Add, Edit
    }

    public class ProductViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<Product> _productsList;
        private Product _itemToEdit;

        private string _addOrEditButtonText;
        private string _addOrEditTabText;
        private ProductOperationType _productOperationType;
        private string _productName;
        private string _productCalories;
        private string _productPrice;
        private string _productAmount;
        private WeightType _productWeightType;


        public ProductViewModel(NavigationStore navigationStore, ProductOperationType productOperationType,
            IList<Product> productsList, AuthenticationStore authenticationStore,UnitOfWorkFactory unitOfWorkFactory, Product itemToEdit = null)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;
            _productOperationType = productOperationType;
            _productsList = productsList;
            _itemToEdit = itemToEdit;

            // TODO: Use converter
            AddOrEditButtonText = _productOperationType == ProductOperationType.Add ? "Добавить" : "Подтвердить";
            AddOrEditTabText = _productOperationType == ProductOperationType.Add ? "Добавление" : "Редактирование";
            AddOrEditProductCommand = _productOperationType == ProductOperationType.Add
                ? new AddProductCommand(this, _unitOfWorkFactory)
                : new EditProductCommand(this, _unitOfWorkFactory);

            NavigateToProductsCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, () => new ProductsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            WeightTypeViewModel = new EnumMenuViewModel<WeightType>();
            WeightTypeViewModel.OnSelectionChanged += () => ProductWeightType = WeightTypeViewModel.SelectedItem;

            ProductWeightType = WeightType.Kg;
            if (_productOperationType == ProductOperationType.Edit && _itemToEdit != null)
            {
                ProductName = _itemToEdit.Name;
                ProductAmount = _itemToEdit.Amount.ToString();
                ProductCalories = _itemToEdit.Calories.ToString();
                ProductPrice = _itemToEdit.Price.ToString();
                WeightTypeViewModel.SelectedItem = _itemToEdit.WeightType;
            }
        }

      

        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }
        public string ProductName
        {
            get => _productName;
            set => Set(ref _productName, value);
        }

        public string ProductCalories
        {
            get => _productCalories;
            set => Set(ref _productCalories, value);
        }

        public string ProductPrice
        {
            get => _productPrice;
            set => Set(ref _productPrice, value);
        }

        public string ProductAmount
        {
            get => _productAmount;
            set => Set(ref _productAmount, value);
        }

        public WeightType ProductWeightType
        {
            get => _productWeightType;
            set => Set(ref _productWeightType, value);
        }
        public string AddOrEditButtonText
        {
            get => _addOrEditButtonText;
            set => Set(ref _addOrEditButtonText, value);
        }

        public string AddOrEditTabText
        {
            get => _addOrEditTabText;
            set => Set(ref _addOrEditTabText, value);
        }
        public Product ItemToEdit
        {
            get => _itemToEdit;
            set => Set(ref _itemToEdit, value);
        }
        public EnumMenuViewModel<WeightType> WeightTypeViewModel { get; }

        public ICommand AddOrEditProductCommand { get; }
        public ICommand NavigateToProductsCommand { get; }


    }
}
