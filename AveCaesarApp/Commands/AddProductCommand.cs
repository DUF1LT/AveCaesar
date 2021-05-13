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
            if (_productViewModel.ProductAmount == 0 ||
                _productViewModel.ProductCalories == 0 ||
                string.IsNullOrEmpty(_productViewModel.ProductName) ||
                _productViewModel.ProductPrice == 0)
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
                    Calories = _productViewModel.ProductCalories,
                    Price = _productViewModel.ProductPrice,
                    Amount = _productViewModel.ProductAmount,
                    WeightType = _productViewModel.ProductWeightType,
                    PriceWeightType = (WeightType)_productViewModel.PriceWeightType
                };

                unitOfWork.ProductRepository.Create(newProd);
                await unitOfWork.SaveAsync();
            }

            _productViewModel.ProductName = string.Empty;
            _productViewModel.ProductAmount = 0;
            _productViewModel.ProductCalories = 0;
            _productViewModel.ProductPrice = 0;
        }
    }
}
