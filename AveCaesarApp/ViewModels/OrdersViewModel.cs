﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class OrdersViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<Order> _ordersList = new BindingList<Order>()
        {
            new Order(1,
                2,
                new BindingList<Dish>()
            {
                new(1, "Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,
                    new BindingList<Product>()
                    {
                        new(1, "Помидор", 25, 10, 10, "кг"),
                        new (2, "Помидор", 25, 10, 10, "кг"),
                        new (3, "Масло", 25, 10, 10, "л" ),
                    },  
                    WeightType.Kg,
                    DishType.Salad)
            },
                DateTime.Now,
                DateTime.Now,
                OrderStatus.Accepted,
                "Погорячее"
            ),

            new Order(1,
                2,
                new BindingList<Dish>()
                {
                    new(1, "Цезарь", @"pack://application:,,,/Images/Dishes/Caesar.jpg", 10, 20,
                        new BindingList<Product>()
                        {
                            new(1, "Помидор", 25, 10, 10, "кг"),
                            new (2, "Помидор", 25, 10, 10, "кг"),
                            new (3, "Масло", 25, 10, 10, "л" ),
                        },
                        WeightType.Kg,
                        DishType.Salad)
                },
                DateTime.Now,
                DateTime.Now,
                OrderStatus.Accepted,
                "Погорячее"
            )
        };

        private Order _selectedItem;

        public OrdersViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;
            

            NavigateToHomeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToSelectedOrderCommand = new NavigateToSelectedOrderCommand(navigationStore,_authenticationStore,  this, _unitOfWorkFactory);

            DeleteSelectedItem = new DeleteSelectedItemCommand<Order>(_ordersList);
        }

        public IList<Order> OrdersList
        {
            get => _ordersList;
            set => Set(ref _ordersList, value);
        }

        public Order SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToSelectedOrderCommand { get; }
        public DeleteSelectedItemCommand<Order> DeleteSelectedItem { get; }


    }
}
