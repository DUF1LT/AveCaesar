using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum DishWeightType
    {
        [Display(Name = "гр")]
        G = 2,
        [Display(Name = "мл")]
        Ml = 4,
     
    }
    public enum DishType
    {
        [Display(Name = "Роллы")]
        Rolls = 1,
        [Display(Name = "Cэндвич")]
        Sandwich,
        [Display(Name = "Суп")]
        Soup,
        [Display(Name = "Боул")]
        Bowl,
        [Display(Name = "Салат")]
        Salad,
        [Display(Name = "Десерт")]
        Dessert,
        [Display(Name = "Напиток")]
        Beverages,
        [Display(Name = "Смузи")]
        Smoothie 
    }

    public class Dish : Item
    {
        public Dish()
        {
            
        }

        public Dish(
            int id,
            string name,
            string image,
            int weight,
            float price,
            IList<Product> products,
            WeightType weightType,
            DishType dishType) : base(id)
        {
            Name = name;
            Image = image;
            Weight = weight;
            Price = price;
            WeightType = weightType;
            DishType = dishType;
        }


        public string Name { get; set; }
        public string Image { get; set; }
        public int Weight { get; set; }
        public float Price { get; set; }
        public WeightType WeightType { get; set; }
        public DishType DishType { get; set; }
        public IList<ProductsDishes> ProductsDishes { get; set; }
        public IList<DishesOrders> DishesOrders { get; set; }
    }
}
