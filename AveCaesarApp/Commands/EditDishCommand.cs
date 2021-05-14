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
    class EditDishCommand : Command
    {
        private readonly DishViewModel _dishViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public EditDishCommand(DishViewModel dishViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _dishViewModel = dishViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_dishViewModel.Name) && !string.IsNullOrEmpty(_dishViewModel.Image) && _dishViewModel.Price != 0 && _dishViewModel.ProductsToAdd != null;
        }

        public override async void Execute(object parameter)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var dishToEdit = unitOfWork.DishRepository.Get(_dishViewModel.dishToEdit.Id);
                dishToEdit.Name = _dishViewModel.Name;
                dishToEdit.Price = _dishViewModel.Price;
                dishToEdit.Image = _dishViewModel.Image;
                dishToEdit.Weight = _dishViewModel.Weight;
                dishToEdit.WeightType = (WeightType)_dishViewModel.DishWeightType;
                dishToEdit.DishType = _dishViewModel.DishType;
                dishToEdit.ProductsDishes.Clear();
                foreach (var productToAdd in _dishViewModel.ProductsToAdd)
                {
                    var newProductDishes = new ProductsDishes()
                    {
                        Product = await unitOfWork.ProductRepository.Get(productToAdd.Product.Id),
                        Dish = dishToEdit,
                        ProductAmount = productToAdd.Amount
                    };
                    dishToEdit.ProductsDishes.Add(newProductDishes);
                }
                unitOfWork.DishRepository.Update(dishToEdit);
                await unitOfWork.SaveAsync();
                _dishViewModel.NavigateToDishesCommand.Execute(null);
            }
        }
    }
}
