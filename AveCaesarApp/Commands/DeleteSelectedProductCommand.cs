using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AveCaesarApp.Models;

namespace AveCaesarApp.Commands
{
    class DeleteSelectedProductCommand : Command
    {
        private IList<Product> _productList;
        public DeleteSelectedProductCommand( IList<Product> productList)
        {
            _productList = productList;
        }
        public override bool CanExecute(object parameter)
        {
            ListView listView = parameter as ListView;
            if (listView != null)
            {
                if (listView?.SelectedItems.Count != 0)
                    return true;
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            ListView listView = parameter as ListView;
            if (listView != null)
            {
                while (listView?.SelectedItems.Count != 0)
                {
                    _productList.RemoveAt(listView.Items.IndexOf(listView.SelectedItems[0]));
                }
            }
        }
    }
}
