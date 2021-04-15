using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public class ProductViewModel : ViewModel
    {
        private IList<Product> _productsList;
        private string _addOrEditButtonText;
        public IList<Product> ProductsList
        {
            get => _productsList;
            set => Set(ref _productsList, value);
        }
        public string AddOrEditButtonText
        {
            get => _addOrEditButtonText;
            set => Set(ref _addOrEditButtonText, value);
        }
        public AddProductCommand AddOrEditProductCommand { get; }
    }
}
