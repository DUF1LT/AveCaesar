using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Repository;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class EditProductCommand : Command
    {
        private ProductViewModel _productViewModel;
        private UnitOfWorkFactory _unitOfWorkFactory;
        public EditProductCommand(ProductViewModel productViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _productViewModel = productViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override bool CanExecute(object parameter) => true;

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var itemToEdit = await unitOfWork.ProductRepository.Get(_productViewModel.ItemToEdit.Id);
                itemToEdit.Name = _productViewModel.ProductName;
                itemToEdit.Price = _productViewModel.ProductPrice;
                itemToEdit.Amount= _productViewModel.ProductAmount + _productViewModel.ProductAddingAmount;
                itemToEdit.Calories = _productViewModel.ProductCalories;
                itemToEdit.WeightType = _productViewModel.ProductWeightType;
                await unitOfWork.SaveAsync();
            }
            _productViewModel.NavigateToProductsCommand.Execute(null);
        }
    }
}
