using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;
using AveCaesarApp.Stores;

namespace AveCaesarApp.ViewModels
{
    class ProductsViewModel : ViewModel
    {

        private IList<Product> _productsList = new BindingList<Product>()
        {
            new(1, "Помидор", 25, 10, 10, "кг"),
            new (2, "Помидор", 25, 10, 10, "кг"),
            new (3, "Масло", 25, 10, 10, "л" ),
            new (2, "Помидор", 25, 10, 10, "кг"),
            new (1, "Помидор", 25, 10, 10, "кг"),     
            new (2, "Помидор", 25, 10, 10, "кг"),
            new (2, "Помидор", 25, 10, 10, "кг"),
            new (2, "Помидор", 25, 10, 10, "кг"),

        };

        private Product _selectedItem;

        public ProductsViewModel(NavigationStore navigationStore)
        {
            DeleteItemCommand = new DeleteSelectedItemCommand<Product>(_productsList);

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));

            NavigateToAddProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Add, _productsList));

            NavigateToEditProductCommand = new NavigateToEditProductCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, ProductOperationType.Edit, _productsList, _selectedItem ));

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
        public ICommand NavigateToAddProductCommand { get;  }
        public ICommand NavigateToEditProductCommand { get; }

        public DeleteSelectedItemCommand<Product> DeleteItemCommand { get; }
    }
}
