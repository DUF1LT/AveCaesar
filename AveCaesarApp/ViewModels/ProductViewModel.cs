using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public enum ProductType
    {
        Add, Edit
    }

    public class ProductViewModel : ViewModel
    {
        private IList<Product> _productsList;
        private string _addOrEditButtonText;
        private string _addOrEditTabText;
        private ProductType _productType;
        private string _productName = "";
        private string _productCalories = "";
        private string _productPrice = "";
        private string _productAmount = "";


        public ProductViewModel(NavigationStore navigationStore, IList<Product> productsList, ProductType productType)
        {
            _productType = productType;
            _productsList = productsList;

            AddOrEditButtonText = _productType == ProductType.Add ? "Добавить" : "Отредактировать";
            AddOrEditTabText = _productType == ProductType.Add ? "Добавление" : "Редактирование";

            NavigateToProductsCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, () => new ProductsViewModel(navigationStore));

            AddOrEditProductCommand = _productType == ProductType.Add ? new AddProductCommand(AddProductCommandExecute, AddProductCommandCanExecute) : null;

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

        public AddProductCommand AddOrEditProductCommand { get; }

        private bool AddProductCommandCanExecute(object arg)
        {
            if (ProductAmount == "" || ProductCalories == "" || ProductName == "" || ProductPrice == "")
                return false;
            return true;
        }
        private void AddProductCommandExecute(object obj)
        {
            Product newProd = new Product(10, ProductName, Convert.ToInt32(ProductCalories),
                Convert.ToInt32(ProductPrice), Convert.ToInt32(ProductAmount), WeightType.кг.ToString());
            ProductsList.Add(newProd);
            ProductName = "";
            ProductAmount = "";
            ProductCalories = "";
            ProductPrice = "";
        }


        public ICommand NavigateToProductsCommand { get; }

        
    }
}
