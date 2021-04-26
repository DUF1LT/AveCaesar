using System.Collections.Generic;
using System.Linq;
using AveCaesarApp.Models;

namespace AveCaesarApp.Commands
{
    class DeleteSelectedItemCommand<T> : Command
        where T : Item
    {
        private IList<T> _itemsList;
        public DeleteSelectedItemCommand(IList<T> itemsList)
        {
            _itemsList = itemsList;
        }

        public override bool CanExecute(object parameter)
        {

            return (parameter is T);
        }

        public override void Execute(object parameter)
        {
            var productParameter = parameter as T;
            int id = productParameter.Id;
            var productToDelete = _itemsList.FirstOrDefault(e => e.Id == id);
            if (productToDelete != null)
                _itemsList.Remove(productToDelete);
        }
    }
}
