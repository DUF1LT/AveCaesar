using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AveCaesarApp.Commands;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.ViewModels
{
    class DishProductsViewModel : ViewModel
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private string _searchExpression;
        private IList<ProductToAdd> _productsToAdd;
        private IList<ProductToAdd> _filteredList;
        private IList<ProductToAdd> _defaultList;


        public DishProductsViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, 
            string name, int price, int weight, string image, DishType dishType, DishWeightType dishWeightType ,IList<ProductToAdd> productsToAdd)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _productsToAdd = productsToAdd;

            NavigateToDishCommand = new NavigateCommand<DishViewModel>(navigationStore,
                () => new DishViewModel(navigationStore, authenticationStore, unitOfWorkFactory, name, price, weight, image, dishType, dishWeightType, _productsToAdd));

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

    
        public IList<ProductToAdd> FilteredList
        {
            get => _filteredList;
            set => Set(ref _filteredList, value);
        }
        public ICommand NavigateToDishCommand { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand AddProductsToDishCommand { get; }

       

        private bool AddProductsToDishCommandCanExecute(object arg) => _defaultList.Count(p => p.IsSelected) > 0;

        private void AddProductsToDishCommandExecute(object obj)
        {
            _productsToAdd = _defaultList.Where(p => p.IsSelected).ToList();
            NavigateToDishCommand.Execute(null);
        }


        private void LoadProducts()
        {
            FilteredList = _defaultList = new List<ProductToAdd>();
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

                    FilteredList.Add(productToAdd);
                }
            }
        }

        private void SearchExpressionChanged()
        {
            if (SearchExpression == string.Empty)
                FilteredList = _defaultList;
            else
            {
                FilteredList = _defaultList.Where(p =>p.Product.Name.ToLower().Contains(SearchExpression.ToLower())).ToList();
            }
        }




    }
}
