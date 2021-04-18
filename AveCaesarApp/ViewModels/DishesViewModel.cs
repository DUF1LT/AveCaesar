using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class DishesViewModel : ViewModel
    {
        private IList<Dish> _dishesList = new BindingList<Dish>()
        {
            new (1,"Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20, 300,200,150, WeightType.кг, DishType.Salad),
            new (1,"Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20, 300,200,150, WeightType.кг, DishType.Salad)

        };
        private Dish _selectedItems;

        private BindingList<string> _menuItems = new BindingList<string>()
        {
            "Все",
            "Роллы",
            "Сендвичи",
            "Супы",
            "Боулы",
            "Салаты",
            "Десерты",
            "Напитки",
            "Смузи"
        };

        public DishesViewModel(NavigationStore navigationStore)
        {
            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }

        public ICommand NavigateToHomeCommand { get; }

        public IList<Dish> DishesList
        {
            get => _dishesList;
            set => Set(ref _dishesList, value);
        }

        public Dish SelectedItems
        {
            get => _selectedItems;
            set => Set(ref _selectedItems, value);
        }

        public BindingList<string> MenuItems
        {
            get => _menuItems;
            set => Set(ref _menuItems, value);
        }
    }
}
