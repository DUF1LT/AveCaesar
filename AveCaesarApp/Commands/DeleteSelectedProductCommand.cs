using System.Collections.Generic;
using System.Linq;
using AveCaesarApp.Models;

namespace AveCaesarApp.Commands
{
    class DeleteSelectedProductCommand : Command
    {
        private IList<Product> _productList;
        public DeleteSelectedProductCommand(IList<Product> productList)
        {
            _productList = productList;
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is Product;
        }

        public override void Execute(object parameter)
        {
            var productParameter = parameter as Product;
            int id = productParameter.ID;
            var productToDelete = _productList.FirstOrDefault(e => e.ID == id);
            if (productToDelete != null)
                _productList.Remove(productToDelete);
        }
    }
}
