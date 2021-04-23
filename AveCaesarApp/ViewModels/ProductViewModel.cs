using System;
using System.Collections.Generic;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
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
        private IList<Product> _productsList;
        private Product _selectedItem;
        private string _addOrEditButtonText;
        private string _addOrEditTabText;
        private ProductOperationType _productOperationType;
        private string _productName;
        private string _productCalories;
        private string _productPrice;
        private string _productAmount;


        public ProductViewModel(NavigationStore navigationStore, ProductOperationType productOperationType,
            IList<Product> productsList, Product selectedItem = null)
        {
            _productOperationType = productOperationType;
            _productsList = productsList;
            _selectedItem = selectedItem;

            // TODO: Use converter
            AddOrEditButtonText = _productOperationType == ProductOperationType.Add ? "Добавить" : "Отредактировать";
            AddOrEditTabText = _productOperationType == ProductOperationType.Add ? "Добавление" : "Редактирование";

            NavigateToProductsCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, () => new ProductsViewModel(navigationStore));

            AddOrEditProductCommand = _productOperationType == ProductOperationType.Add
                ? new RelayCommand(AddProductCommandExecute, AddProductCommandCanExecute)
                : new RelayCommand(EditProductCommandExecute, EditProductCommandCanExecute);

            if(_productOperationType == ProductOperationType.Edit)
            {
                ProductName = _selectedItem.Name;
                ProductAmount = _selectedItem.Amount.ToString();
                ProductCalories = _selectedItem.Calories.ToString();
                ProductPrice = _selectedItem.Price.ToString();
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

        public ICommand AddOrEditProductCommand { get; }

        private bool AddProductCommandCanExecute(object arg)
        {

            if (string.IsNullOrEmpty(ProductAmount) ||
                string.IsNullOrEmpty(ProductCalories) ||
                string.IsNullOrEmpty(ProductName) ||
                string.IsNullOrEmpty(ProductPrice))
                return false;
            return true;
        }
        private void AddProductCommandExecute(object obj)
        {
            Product newProd = new Product(10, ProductName, Convert.ToInt32(ProductCalories),
                Convert.ToInt32(ProductPrice), Convert.ToInt32(ProductAmount), WeightType.Kg.ToString());
            ProductsList.Add(newProd);
            ProductName = string.Empty;
            ProductAmount = string.Empty;
            ProductCalories = string.Empty;
            ProductPrice = string.Empty;
        }

        private bool EditProductCommandCanExecute(object arg) => true;

        private void EditProductCommandExecute(object obj)
        {
            //TODO: EditProduct when DB will be connected
        }


        public ICommand NavigateToProductsCommand { get; }
    }
}
