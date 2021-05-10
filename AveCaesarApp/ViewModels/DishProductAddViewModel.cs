using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class DishProductAddViewModel : ViewModel
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private string _searchExpression;
        private IList<ProductToAdd> _productsToAddList;
        private IList<ProductToAdd> _defaultList;


        public DishProductAddViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, 
            string name, int price, string image, DishType dishType, IList<ProductToAdd> productsToAdd)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
          
            NavigateToDishCommand = new NavigateCommand<DishViewModel>(navigationStore,
                () => new DishViewModel(navigationStore, authenticationStore, unitOfWorkFactory, name, price, image, dishType, ProductsToAdd));

            NavigateToHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore,
                () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            AddProductsToDishCommand =
                new RelayCommand(AddProductsToDishCommandExecute, AddProductsToDishCommandCanExecute);

            LoadProducts();
        }

       

 
        public string SearchExpression
        {
            get => _searchExpression;
            set
            {
                Set(ref _searchExpression, value);
                SearchExpressionChanged();
            }
        }

    
        public IList<ProductToAdd> ProductsToAdd
        {
            get => _productsToAddList;
            set => Set(ref _productsToAddList, value);
        }
        public ICommand NavigateToDishCommand { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand AddProductsToDishCommand { get; }

       

        private bool AddProductsToDishCommandCanExecute(object arg)
        {
            return true;
        }

        private void AddProductsToDishCommandExecute(object obj)
        {
            throw new NotImplementedException();
        }


        private void LoadProducts()
        {
            ProductsToAdd = _defaultList = new List<ProductToAdd>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var list = unitOfWork.ProductRepository.GetAll().ToList();
                foreach (Product product in list)
                {
                    var productToAdd = new ProductToAdd()
                    {
                        Product = product,
                        Amount = 0,
                        IsSelected = false
                    };

                    ProductsToAdd.Add(productToAdd);
                }
            }
        }

        private void SearchExpressionChanged()
        {
            if (SearchExpression == string.Empty)
                ProductsToAdd = _defaultList;
            else
            {
                ProductsToAdd = _defaultList.Where(p =>p.Product.Name.ToLower().Contains(SearchExpression.ToLower())).ToList();
            }
        }




    }
}
