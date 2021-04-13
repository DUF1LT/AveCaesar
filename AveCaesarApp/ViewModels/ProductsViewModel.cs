using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class ProductsViewModel : ViewModel
    {
        public ProductsViewModel()
        {
            DeleteCommand = new DeleteSelectedProductCommand(_productsList);
        }
        #region Properties
        
        #region MainWindowView

        private ViewModel _mainWindowView;

        public ViewModel MainWindowView
        {
            get => _mainWindowView;
            set => Set(ref _mainWindowView, value);
        }

        #endregion

        #region ProductsList

        private IList<Product> _productsList = new BindingList<Product>()
        {
            new Product(1, "Помидор", 25, 10, 10, "кг"),
            new Product(2, "Помидор", 25, 10, 10, "кг"),
            new Product(3, "Масло", 25, 10, 10, "л" ),
            new Product(2, "Помидор", 25, 10, 10, "кг"),
            new Product(1, "Помидор", 25, 10, 10, "кг"),
            new Product(2, "Помидор", 25, 10, 10, "кг"),
            new Product(2, "Помидор", 25, 10, 10, "кг"),
            new Product(2, "Помидор", 25, 10, 10, "кг"),

        };

        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }

        #endregion


        #endregion

        #region Commands

        #region BackToMainWindow

        public BackToMainWindowCommand BackToMainWindowCommand { get; }


        #endregion


        #region DeleteSelectedProductCommand

        public DeleteSelectedProductCommand DeleteCommand { get; }

        #endregion

        #endregion


    }
}
