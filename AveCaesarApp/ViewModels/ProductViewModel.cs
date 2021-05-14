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
    public enum ItemOperationType
    {
        Add,
        Edit
    }

    public class ProductViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<Product> _productsList;
        private Product _itemToEdit;

        private string _addOrEditTabText;
        private string _productName;
        private int _productCalories;
        private float _productPrice;
        private float _productAmount;
        private float _productAddingAmount;
        private WeightType _productWeightType;
        private PriceWeightType _priceWeightType;


        public ProductViewModel(NavigationStore navigationStore, ItemOperationType itemOperationType,
            IList<Product> productsList, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, Product itemToEdit = null)
        {
            ItemOperationType = itemOperationType;
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;
            _productsList = productsList;
            _itemToEdit = itemToEdit;

            AddOrEditTabText = itemOperationType == ItemOperationType.Add ? "Добавление" : "Редактирование";
            AddOrEditProductCommand = itemOperationType == ItemOperationType.Add
                ? new AddProductCommand(this, _unitOfWorkFactory)
                : new EditProductCommand(this, _unitOfWorkFactory);

            NavigateToProductsCommand =
                new NavigateCommand<ProductsViewModel>(navigationStore, () => new ProductsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            WeightTypeViewModel = new EnumMenuViewModel<WeightType>();
            WeightTypeViewModel.OnSelectionChanged +=
                () => ProductWeightType = WeightTypeViewModel.SelectedItem;

            PriceWeightTypeViewModel = new EnumMenuViewModel<PriceWeightType>();
            PriceWeightTypeViewModel.OnSelectionChanged +=
                () => PriceWeightType = PriceWeightTypeViewModel.SelectedItem;

            ProductWeightType = WeightType.Kg;
            PriceWeightType = PriceWeightType.Kg;
            if (itemOperationType == ItemOperationType.Edit && _itemToEdit != null)
            {
                ProductName = _itemToEdit.Name;
                ProductAmount = _itemToEdit.Amount;
                ProductCalories = _itemToEdit.Calories;
                ProductPrice = _itemToEdit.Price;
                WeightTypeViewModel.SelectedItem = _itemToEdit.WeightType;
                PriceWeightTypeViewModel.SelectedItem = (PriceWeightType)_itemToEdit.PriceWeightType;
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

        public int ProductCalories
        {
            get => _productCalories;
            set => Set(ref _productCalories, value);
        }

        public float ProductPrice
        {
            get => _productPrice;
            set => Set(ref _productPrice, value);
        }

        public float ProductAmount
        {
            get => _productAmount;
            set => Set(ref _productAmount, value);
        }
        public float ProductAddingAmount
        {
            get => _productAddingAmount;
            set => Set(ref _productAddingAmount, value);
        }

        public WeightType ProductWeightType
        {
            get => _productWeightType;
            set => Set(ref _productWeightType, value);
        }
        public PriceWeightType PriceWeightType
        {
            get => _priceWeightType;
            set => Set(ref _priceWeightType, value);
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
        public EnumMenuViewModel<PriceWeightType> PriceWeightTypeViewModel { get; }
        public ItemOperationType ItemOperationType { get; }

        public ICommand AddOrEditProductCommand { get; }
        public ICommand NavigateToProductsCommand { get; }


    }
}
