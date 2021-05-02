using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public class ProductWeightTypeViewModel : ViewModel
    {
        private IList<WeightType> _items;
        private WeightType _selectedItem;
        public event Action OnSelectionChanged;

        public ProductWeightTypeViewModel()
        {
            Items = Enum.GetValues<WeightType>().ToList();
            SelectedItem = WeightType.Kg;
        }

        public IList<WeightType> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public WeightType SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnSelectionChanged?.Invoke();
            }
        }
    }
}
