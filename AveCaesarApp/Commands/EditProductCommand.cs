using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Commands
{
    class EditProductCommand : Command
    {
        private ProductViewModel _productViewModel;
        public EditProductCommand(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            //TODO: EditProduct when DB will be connected

        }
    }
}
