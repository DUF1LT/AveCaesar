using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
