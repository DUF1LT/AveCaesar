﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class DishesViewModel : ViewModel
    {
        private IList<Dish> _defaultList = new BindingList<Dish>()
        {
            new(1, "Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,  
                new BindingList<Product>()
                {
                    new(1, "Помидор", 25, 10, 10, "кг"), 
                    new (2, "Помидор", 25, 10, 10, "кг"),
                    new (3, "Масло", 25, 10, 10, "л" ),

                },
                WeightType.Kg,
                DishType.Salad),
            new(2, "Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,
                new BindingList<Product>()
                {
                    new(1, "Помидор", 25, 10, 10, "кг"),
                    new (2, "Помидор", 25, 10, 10, "кг"),
                    new (3, "Масло", 25, 10, 10, "л" ),

                }, WeightType.Kg,
                DishType.Salad),
            new(3, "Смузи", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,
                new BindingList<Product>()
                {
                    new(1, "Помидор", 25, 10, 10, "кг"),
                    new (2, "Помидор", 25, 10, 10, "кг"),
                    new (3, "Масло", 25, 10, 10, "л" ),

                }, WeightType.Kg,
            DishType.Smoothie),
            new(4, "Сэндвич", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,
                new BindingList<Product>()
                {
                    new(1, "Помидор", 25, 10, 10, "кг"),
                    new (2, "Помидор", 25, 10, 10, "кг"),
                    new (3, "Масло", 25, 10, 10, "л" ),

                },WeightType.Kg,
            DishType.Sandwich)
        };

        private IList<Dish> _dishesList;
        private Dish _selectedItem;

        //TODO: Unsubscribe event listener
        public DishesViewModel(NavigationStore navigationStore)
        {

            FilterViewModel = new DishesFilterViewModel();

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));

            FilterViewModel.OnSelectionChanged += FilterViewModelOnOnSelectionChanged;

            DishesList = DefaultList;
            DeleteSelectedItem = new DeleteSelectedItemCommand<Dish>(DefaultList);

        }

        private void FilterViewModelOnOnSelectionChanged()
        {
            SelectedItem = null;
            if (FilterViewModel.SelectedItem == DishesFilterViewModel.DishTypeFilter.All)
            {
                DishesList = DefaultList;
            }
            else
            {
                DishesList = DefaultList.Where(el => el.DishType == (DishType)FilterViewModel.SelectedItem).ToList();
            }
        }

        public IList<Dish> DishesList
        {
            get => _dishesList;
            set => Set(ref _dishesList, value);
        }

        public Dish SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<Dish> DefaultList
        {
            get => _defaultList;
            set => Set(ref _defaultList, value);
        }

        public DishesFilterViewModel FilterViewModel { get; set; }

        public ICommand NavigateToHomeCommand { get; }
        public DeleteSelectedItemCommand<Dish> DeleteSelectedItem { get; }
    }
}
