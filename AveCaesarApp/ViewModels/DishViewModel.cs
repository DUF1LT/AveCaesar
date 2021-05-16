using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private float _price;
        private int _weight;
        private string _image;
        private DishType _dishType;
        private DishWeightType _dishWeightType;
        private IList<ProductToAdd> _productsToAdd;

        public Dish dishToEdit;

        public DishViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory, ItemOperationType itemOperationType, 
            Dish dishToEdit = null, string name = null, float price = 0, int weight = 0 ,string image = "../Images/imageholder.png", DishType dishType = DishType.Rolls, 
            DishWeightType dishWeightType = DishWeightType.G, IList<ProductToAdd> productsToAdd = null)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.dishToEdit = dishToEdit;
            OperationType = itemOperationType;

            DishWeightTypeViewModel = new EnumMenuViewModel<DishWeightType>();
            DishWeightTypeViewModel.OnSelectionChanged +=
                () => DishWeightType = DishWeightTypeViewModel.SelectedItem;

            DishTypeViewModel = new EnumMenuViewModel<DishType>();
            DishTypeViewModel.OnSelectionChanged += 
                () => DishType = DishTypeViewModel.SelectedItem;

            if (itemOperationType == ItemOperationType.Add)
            {
                Name = name;
                Price = price;
                Weight = weight;
                Image = image;
                
                DishTypeViewModel.SelectedItem = DishType = dishType;
                DishWeightTypeViewModel.SelectedItem = DishWeightType = dishWeightType;
                ProductsToAdd = productsToAdd;


                AddOrEditDishCommand = new AddDishCommand(this, _unitOfWorkFactory);
            }
            if(itemOperationType == ItemOperationType.Edit && dishToEdit != null)
            {
                this.dishToEdit = dishToEdit;
                Name = this.dishToEdit.Name;
                Price = this.dishToEdit.Price;
                Weight = this.dishToEdit.Weight;
                Image = this.dishToEdit.Image;

                DishTypeViewModel.SelectedItem = this.dishToEdit.DishType;
                DishWeightTypeViewModel.SelectedItem = (DishWeightType)this.dishToEdit.WeightType;

                var list = new List<ProductToAdd>();
                foreach (var product in this.dishToEdit.ProductsDishes)
                {
                    list.Add(new ProductToAdd()
                    {
                        Product = product.Product,
                        Amount = product.ProductAmount,
                        IsSelected = true
                    });
                }
                if (productsToAdd == null)
                    ProductsToAdd = list;
                else
                    ProductsToAdd = productsToAdd;
                AddOrEditDishCommand = new EditDishCommand(this, _unitOfWorkFactory);
            }

            NavigateToDishesCommand = new NavigateCommand<DishesViewModel>(navigationStore,
                () => new DishesViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore,
                () => new HomeViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToDishProductAddCommand = new NavigateCommand<DishProductsViewModel>(navigationStore,
                () => new DishProductsViewModel(navigationStore, authenticationStore, unitOfWorkFactory, itemOperationType, dishToEdit, Name , Price, Weight , Image , DishType, DishWeightType, ProductsToAdd));

           
        }


        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public float Price
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
       
        public ItemOperationType OperationType { get; }
        public EnumMenuViewModel<DishType> DishTypeViewModel { get; }
        public EnumMenuViewModel<DishWeightType> DishWeightTypeViewModel { get; }

        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToDishesCommand { get; }
        public ICommand NavigateToDishProductAddCommand { get; }
        public ICommand AddOrEditDishCommand { get; }

        
    }
}
