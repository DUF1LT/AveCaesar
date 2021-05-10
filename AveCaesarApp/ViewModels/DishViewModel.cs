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
        private int _weight;
        private string _image;
        private DishType _dishType;
        private DishWeightType _dishWeightType;
        private IList<ProductToAdd> _productsToAdd;

        public DishViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, 
            string name = null, int price = 0, int weight = 0 ,string image = null, DishType dishType = DishType.Rolls, DishWeightType dishWeightType = DishWeightType.G  , IList<ProductToAdd> productsToAdd = null)
        {
            _unitOfWorkFactory = unitOfWorkFactory;


            Name = name;
            Price = price;
            Weight = weight;
            Image = image;
            DishTypeViewModel = new EnumMenuViewModel<DishType>();
            DishTypeViewModel.OnSelectionChanged += () => DishType = DishTypeViewModel.SelectedItem;
            DishTypeViewModel.SelectedItem = DishType = dishType;
            ProductsToAdd = productsToAdd;

            DishWeightTypeViewModel = new EnumMenuViewModel<DishWeightType>();
            DishWeightTypeViewModel.OnSelectionChanged += () => DishWeightType = DishWeightTypeViewModel.SelectedItem;
            DishWeightTypeViewModel.SelectedItem = DishWeightType = dishWeightType;

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore,
                () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToDishProductAddCommand = new NavigateCommand<DishProductAddViewModel>(navigationStore,
                () => new DishProductAddViewModel(navigationStore, authenticationStore, unitOfWorkFactory, Name , Price, Weight , Image , DishType, DishWeightType ,ProductsToAdd));

            AddDishCommand = new AddDishCommand(this, _unitOfWorkFactory);
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
        public int Weight
        {
            get => _weight;
            set => Set(ref _weight, value);
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

        public DishWeightType DishWeightType
        {
            get => _dishWeightType;
            set => Set(ref _dishWeightType, value);
        }

        public EnumMenuViewModel<DishType> DishTypeViewModel { get; }
        public EnumMenuViewModel<DishWeightType> DishWeightTypeViewModel { get; }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToDishProductAddCommand { get; }
        public ICommand AddDishCommand { get; }

       
    }
}
