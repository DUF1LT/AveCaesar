using System;
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
    class DishViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private string _name;
        private int _price;
        private string _image;
        private DishType _dishType;
        private IList<ProductToAdd> _productsToAdd;

        public DishViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, 
            string name = null, int price = 0, string image = null, DishType dishType = DishType.Salad, IList<ProductToAdd> productsToAdd = null)
        {
            Name = name;
            Price = price;
            Image = image;
            DishType = dishType;
            ProductsToAdd = productsToAdd;

            _unitOfWorkFactory = unitOfWorkFactory;

            DishTypeViewModel = new EnumMenuViewModel<DishType>();
            DishTypeViewModel.OnSelectionChanged += () => DishType = DishTypeViewModel.SelectedItem;

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore,
                () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToDishProductAddCommand = new NavigateCommand<DishProductAddViewModel>(navigationStore,
                () => new DishProductAddViewModel(navigationStore, authenticationStore, unitOfWorkFactory, Name , Price , Image , DishType, ProductsToAdd));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public int Price
        {
            get => _price;
            set => Set(ref _price, value);
        }
        
        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public IList<ProductToAdd> ProductsToAdd
        {
            get => _productsToAdd;
            set => Set(ref _productsToAdd, value);
        }
        public DishType DishType
        {
            get => _dishType;
            set => Set(ref _dishType, value);
        }

        public EnumMenuViewModel<DishType> DishTypeViewModel { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToDishProductAddCommand { get; }


    }
}
