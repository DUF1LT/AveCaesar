using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;
using AveCaesarApp.Stores;

namespace AveCaesarApp.ViewModels
{
    class ProductsViewModel : ViewModel
    {

        private ViewModel _mainWindowView;
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

        private Product _selectedItems;

        public ProductsViewModel()
        {
            DeleteCommand = new DeleteSelectedProductCommand(_productsList);

        }

        public Product SelectedItem
        {
            get => _selectedItems;
            set => Set(ref _selectedItems, value);
        }

        public ViewModel MainWindowView
        {
            get => _mainWindowView;
            set => Set(ref _mainWindowView, value);
        }

        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }

        public DeleteSelectedProductCommand DeleteCommand { get; }


    }
}
