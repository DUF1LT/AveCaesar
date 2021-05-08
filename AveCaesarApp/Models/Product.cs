using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum WeightType
    {
        [Display(Name = "кг")]
        Kg = 1,
        [Display(Name = "гр")]
        G = 2,
        [Display(Name = "л")]
        L = 3,
        [Display(Name = "мл")] 
        Ml = 4,
        [Display(Name = "шт")]
        Unit = 5,
        
    }

    public class Product : Item
    {
        public Product()
        {
        }
        
        public Product(
            int id,
            string name,
            int calories,
            int price,
            int amount,
            string weightType) : base(id)
        {
            Name = name;
            Calories = calories;
            Price = price;
            Amount = amount;
            if (weightType == "кг")
                WeightType = WeightType.Kg;
            else if (weightType == "л")
                WeightType = WeightType.L;
        }

        public string Name { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        public float Amount { get; set; }
        public WeightType WeightType { get; set; }
        public IList<ProductsDishes> ProductDishes { get; set; }

        //public override string ToString()
        //{
        //    return Id + " " + Name + " " + Calories + " " + Price + " " + Amount;
        //}
    }
}
