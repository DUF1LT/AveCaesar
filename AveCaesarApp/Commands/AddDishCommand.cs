using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var dish = unitOfWork.DishRepository.GetAll().FirstOrDefault(p => p.Name == _dishViewModel.Name);
                if (dish == null)
                {
                    Dish newDish = new Dish()
                    {
                        Name = _dishViewModel.Name,
                        DishType = _dishViewModel.DishType,
                        Image = _dishViewModel.Image,
                        Price = _dishViewModel.Price,
                        Weight = _dishViewModel.Weight,
                        WeightType = (WeightType) _dishViewModel.DishWeightType,
                        ProductsDishes = new List<ProductsDishes>(),
                        DishesOrders = new List<DishesOrders>()
                    };
                    foreach (var productToAdd in _dishViewModel.ProductsToAdd)
                    {
                        var newProductDishes = new ProductsDishes()
                        {
                            Product = await unitOfWork.ProductRepository.Get(productToAdd.Product.Id),
                            Dish = newDish,
                            ProductAmount = productToAdd.Amount
                        };
                        newDish.ProductsDishes.Add(newProductDishes);
                    }

                    unitOfWork.DishRepository.Create(newDish);
                    await unitOfWork.SaveAsync();
                }
                else
                {
                    MessageBox.Show($"Блюдо с названием '{_dishViewModel.Name}' уже существует", "Ошибка");
                    return;
                }

            }

            _dishViewModel.Name = string.Empty;
            _dishViewModel.Image = "../Images/imageholder.png";
            _dishViewModel.Price = 0;
            _dishViewModel.Weight = 0;
            _dishViewModel.ProductsToAdd = null;
            _dishViewModel.DishTypeViewModel.SelectedItem = DishType.Rolls;
            _dishViewModel.DishWeightTypeViewModel.SelectedItem = DishWeightType.G;
        }
    }
}
