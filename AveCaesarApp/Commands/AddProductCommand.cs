using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class AddProductCommand : Command
    {
        private ProductViewModel _productViewModel;

        public AddProductCommand(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }
        
        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_productViewModel.ProductAmount) ||
                string.IsNullOrEmpty(_productViewModel.ProductCalories) ||
                string.IsNullOrEmpty(_productViewModel.ProductName) ||
                string.IsNullOrEmpty(_productViewModel.ProductPrice))
                return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            Product newProd = new Product(10, _productViewModel.ProductName, Convert.ToInt32(_productViewModel.ProductCalories),
                Convert.ToInt32(_productViewModel.ProductPrice), Convert.ToInt32(_productViewModel.ProductAmount), WeightType.Kg.ToString());
            _productViewModel.ProductsList.Add(newProd);
            _productViewModel.ProductName = string.Empty;
            _productViewModel.ProductAmount = string.Empty;
            _productViewModel.ProductCalories = string.Empty;
            _productViewModel.ProductPrice = string.Empty;
        }
    }
}
