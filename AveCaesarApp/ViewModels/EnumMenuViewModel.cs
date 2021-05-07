#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public class EnumMenuViewModel<TEnum> : ViewModel where TEnum : struct, Enum
    {
        private IList<TEnum> _items;
        private TEnum _selectedItem;
        public event Action OnSelectionChanged = null!;
            
        public EnumMenuViewModel()
        {
            _items = Enum.GetValues<TEnum>().ToList();
            _selectedItem = Items[0];
        }

        public IList<TEnum> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public TEnum SelectedItem
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
