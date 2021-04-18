using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    public class DishesFilterViewModel : ViewModel
    {
        private IList<DishTypeFilter> _items;
        private DishTypeFilter _selectedItem;
        public event Action OnSelectionChanged;

        public IList<DishTypeFilter> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public DishTypeFilter SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnSelectionChanged?.Invoke();
            }
        }

        public DishesFilterViewModel()
        {
            Items = Enum.GetValues<DishTypeFilter>().ToList();
            SelectedItem = DishTypeFilter.All;
        }

        public enum DishTypeFilter
        {
            [Display(Name = "Все")]
            All = 0,
            [Display(Name = "Роллы")]
            Rolls = 1,
            [Display(Name = "Сендвич")]
            Sandwich,
            [Display(Name = "Супы")]
            Soup,
            [Display(Name = "Боулы")]
            Bowl,
            [Display(Name = "Салаты")]
            Salad,
            [Display(Name = "Десерты")]
            Dessert,
            [Display(Name = "Напитки")]
            Beverages,
            [Display(Name = "Смузи")]
            Smoothie
        }
    }
}