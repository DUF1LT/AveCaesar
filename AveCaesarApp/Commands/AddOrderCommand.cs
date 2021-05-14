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
    class AddOrderCommand : Command
    {
        private readonly OrderViewModel _orderViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AddOrderCommand(OrderViewModel orderViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _orderViewModel = orderViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public override bool CanExecute(object parameter)
        {
            return _orderViewModel.TableNumber != 0 && _orderViewModel.DishesToAdd != null;
        }

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                Order newOrder = new Order()
                {
                    AcceptedTime = DateTime.Now,
                    Note = _orderViewModel.Note,
                    Status = OrderStatus.Accepted,
                    TableNumber = _orderViewModel.TableNumber,
                    WaiterName = _orderViewModel.AuthenticationStore.CurrentProfile.FullName,
                    TotalPrice = _orderViewModel.TotalPrice,
                    DishesOrders = new List<DishesOrders>()
                };
                foreach (var element in _orderViewModel.DishesToAdd)
                {
                    var newOrderDishes = new DishesOrders()
                    {
                        Dish = unitOfWork.DishRepository.Get(element.Dish.Id),
                        DishAmount = element.Amount,
                        Order = newOrder
                    };
                    newOrder.DishesOrders.Add(newOrderDishes);

                    foreach (var productsDish in element.Dish.ProductsDishes)
                    {
                        var updatingProduct = await unitOfWork.ProductRepository.Get(productsDish.ProductId);
                        updatingProduct.Amount -= productsDish.ProductAmount;
                        updatingProduct.Amount = (float)Math.Round(updatingProduct.Amount, 2);
                    }
                }

                unitOfWork.OrderRepository.Create(newOrder);
                await unitOfWork.SaveAsync();
            }
            _orderViewModel.NavigateToOrdersCommand.Execute(null);
        }
    }
}
