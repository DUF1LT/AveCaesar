using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            AddDishesToOrderCommand = new RelayCommand(AddDishesToOrderCommandExecute, AddDishesToOrderCommandCanExecute);
            FilterViewModel = new DishesFilterViewModel();
            FilterViewModel.OnSelectionChanged += FilterViewModelOnOnSelectionChanged;

            LoadDishes();

        }



        public IList<DishToAdd> DishesList
        {
            get => _dishesList;
            set => Set(ref _dishesList, value);
        }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToOrderCommand { get; }
        public ICommand AddDishesToOrderCommand { get; }

        public DishesFilterViewModel FilterViewModel { get; set; }

        private void AddDishesToOrderCommandExecute(object obj)
        {
            foreach (var dishToAdd in DishesList)
            {
                var isNotEnoughProduct = false;

                foreach (var product in dishToAdd.Dish.ProductsDishes)
                {
                    if (product.ProductAmount*dishToAdd.Amount > product.Product.Amount)
                        isNotEnoughProduct = true;
                }
                if (isNotEnoughProduct)
                {
                    MessageBox.Show($"Не хватает продуктов, чтобы приготовить такое количество блюда. '{dishToAdd.Dish.Name}'\nВыберите меньшее количество блюда.", "Ошибка");
                    return;
                }
            }
            _dishesToAdd = DishesList.Where(p => p.IsSelected).ToList();
            NavigateToOrderCommand.Execute(null);
        }
        private bool AddDishesToOrderCommandCanExecute(object arg) => _defaultList.Count(p => p.IsSelected) > 0;


        private void LoadDishes()
        {
            DishesList = _defaultList = new List<DishToAdd>();
            using (var context = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var list = context.DishRepository.GetAll().ToList();
                foreach (var dish in list)
                {
                    var isNotEnoughProduct = false;
                    foreach (var productsDish in dish.ProductsDishes)
                    {
                        if (productsDish.ProductAmount > productsDish.Product.Amount)
                            isNotEnoughProduct = true;
                    }

                    if (isNotEnoughProduct == false)
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
