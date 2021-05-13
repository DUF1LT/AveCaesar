﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class OrderDishesViewModel : ViewModel
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IList<DishToAdd> _dishesToAdd;
        private IList<DishToAdd> _dishesList;
        private IList<DishToAdd> _defaultList;


        public OrderDishesViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            int tableNumber, string note, float totalPrice, IList<DishToAdd> dishesToAdd)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _dishesToAdd = dishesToAdd;


            NavigateToHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore,
                    () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrderCommand = new NavigateCommand<OrderViewModel>(navigationStore,
                () => new OrderViewModel(navigationStore, authenticationStore, unitOfWorkFactory, tableNumber, note, totalPrice, _dishesToAdd));
            AddDishesToOrderCommand = new RelayCommand(AddDishesToOrderCommandExecute);
            FilterViewModel = new DishesFilterViewModel();
            FilterViewModel.OnSelectionChanged += FilterViewModelOnOnSelectionChanged;

            LoadDishes();

        }

       
        public IList<DishToAdd> DishesList
        {
            get => _dishesList;
            set => Set(ref _dishesList, value);
        }
        public ICommand NavigateToHomeCommand { get;  }
        public ICommand NavigateToOrderCommand { get;}
        public ICommand AddDishesToOrderCommand { get; }

        public DishesFilterViewModel FilterViewModel { get; set; }

        private void AddDishesToOrderCommandExecute(object obj)
        {
            _dishesToAdd = DishesList.Where(p => p.IsSelected).ToList();
            NavigateToOrderCommand.Execute(null);
        }

        private void LoadDishes()
        {
            DishesList = _defaultList = new List<DishToAdd>();
            using (var context = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var list = context.DishRepository.GetAll().ToList();
                foreach (var dish in list)
                {
                    var newDishToAdd = new DishToAdd()
                    {
                        Dish = dish,
                        Amount = 0,
                        IsSelected = false
                    };
                    _defaultList.Add(newDishToAdd);
                }
            }
        }
        private void FilterViewModelOnOnSelectionChanged()
        {
            if (FilterViewModel.SelectedItem == DishesFilterViewModel.DishTypeFilter.All)
            {
                DishesList = _defaultList;
            }
            else
            {
                DishesList = _defaultList.Where(el => el.Dish.DishType == (DishType)FilterViewModel.SelectedItem).ToList();
            }
        }

    }
}