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
    class AddDishCommand : Command
    {
        private readonly DishViewModel _dishViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AddDishCommand(DishViewModel dishViewModel, UnitOfWorkFactory unitOfWorkFactory)
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
            using(var context = _unitOfWorkFactory.CreateUnitOfWork())
            {
                Dish newDish = new Dish()
                {
                    Name = _dishViewModel.Name,
                    DishType = _dishViewModel.DishType,
                    Image = _dishViewModel.Image,
                    Price = _dishViewModel.Price,
                    Weight = _dishViewModel.Weight,
                    WeightType = (WeightType)_dishViewModel.DishWeightType, 
                    ProductsDishes = new List<ProductsDishes>(),
                    DishesOrders = new List<DishesOrders>()
                };
                foreach (var productToAdd in _dishViewModel.ProductsToAdd)
                {
                    var newProductDishes = new ProductsDishes()
                    {
                        Product = await context.ProductRepository.Get(productToAdd.Product.Id),
                        Dish = newDish,
                        ProductAmount = productToAdd.Amount
                    };
                    newDish.ProductsDishes.Add(newProductDishes);
                }

                context.DishRepository.Create(newDish);
                await context.SaveAsync();

            }

            _dishViewModel.Name = string.Empty;
            _dishViewModel.Image = string.Empty;
            _dishViewModel.Price = 0;
            _dishViewModel.Weight = 0;
            _dishViewModel.ProductsToAdd = null;
            _dishViewModel.DishTypeViewModel.SelectedItem = DishType.Soup;
            _dishViewModel.DishWeightTypeViewModel.SelectedItem = DishWeightType.G;
        }
    }
}
