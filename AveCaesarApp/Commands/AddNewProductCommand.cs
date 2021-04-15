using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using AveCaesarApp.Models;

namespace AveCaesarApp.Commands
{
    class AddNewProductCommand : Command
    {
        private IList<Product> _productsList;
        public AddNewProductCommand(IList<Product> productsList)
        {
            _productsList = productsList;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {

        }
    }
}
