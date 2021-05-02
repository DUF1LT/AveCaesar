using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class AddProductCommand : Command
    {
        private ProductViewModel _productViewModel;
        private UnitOfWorkFactory _unitOfWorkFactory;

        public AddProductCommand(ProductViewModel productViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _productViewModel = productViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
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

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                Product newProd = new Product()
                {
                    Name = _productViewModel.ProductName,
                    Calories = Convert.ToInt32(_productViewModel.ProductCalories),
                    Price = Convert.ToInt32(_productViewModel.ProductPrice),
                    Amount = Convert.ToInt32(_productViewModel.ProductAmount),
                    WeightType = _productViewModel.ProductWeightType
                };

                unitOfWork.ProductRepository.Create(newProd);
                await unitOfWork.SaveAsync();
            }

            _productViewModel.ProductName = string.Empty;
            _productViewModel.ProductAmount = null;
            _productViewModel.ProductCalories = null;
            _productViewModel.ProductPrice = null;
        }
    }
}
