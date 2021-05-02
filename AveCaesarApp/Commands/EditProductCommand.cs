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
            //TODO: EditProduct when DB will be connected
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var itemToEdit = unitOfWork.ProductRepository.Get(_productViewModel.ItemToEdit.Id);
                itemToEdit.Name = _productViewModel.ProductName;
                itemToEdit.Price = Convert.ToInt32(_productViewModel.ProductPrice);
                itemToEdit.Amount= Convert.ToInt32(_productViewModel.ProductAmount);
                itemToEdit.Calories = Convert.ToInt32(_productViewModel.ProductCalories);
                itemToEdit.WeightType = _productViewModel.ProductWeightType;
                await unitOfWork.SaveAsync();
            }
            _productViewModel.NavigateToProductsCommand.Execute(null);
        }
    }
}
