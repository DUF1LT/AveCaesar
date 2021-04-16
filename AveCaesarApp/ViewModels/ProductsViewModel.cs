﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Product _selectedItems;

        public ProductsViewModel(NavigationStore navigationStore)
        {
            DeleteCommand = new DeleteSelectedProductCommand(_productsList);

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));

            NavigateToAddProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, _productsList, ProductType.Add));

            NavigateToEditProductCommand = new NavigateCommand<ProductViewModel>(navigationStore,
                () => new ProductViewModel(navigationStore, _productsList, ProductType.Edit));

        }

        public Product SelectedItem
        {
            get => _selectedItems;
            set => Set(ref _selectedItems, value);
        }


        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }


        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToAddProductCommand { get;  }
        public ICommand NavigateToEditProductCommand { get; }

        public DeleteSelectedProductCommand DeleteCommand { get; }


    }
}
