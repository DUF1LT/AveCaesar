﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class DishesViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<Dish> _defaultList;
        private IList<Dish> _dishesList;
        private Dish _selectedItem;

        //TODO: Unsubscribe event listener
        public DishesViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            FilterViewModel = new DishesFilterViewModel();

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToAddDishCommand = new NavigateCommand<DishViewModel>(navigationStore, () => new DishViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            FilterViewModel.OnSelectionChanged += FilterViewModelOnOnSelectionChanged;

            DeleteSelectedItem = new DeleteSelectedItemCommand<Dish>(DefaultList);

            LoadDishes();

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
        public ICommand NavigateToAddDishCommand { get; }
        public ICommand DeleteSelectedItem { get; }

        private void LoadDishes()
        {
            using (var context = _unitOfWorkFactory.CreateUnitOfWork())
            {
                DishesList = DefaultList = context.DishRepository.GetAll().ToList();
            }

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
    }

}
