using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum PriceWeightType
    {
        [Display(Name = "кг")]
        Kg = 1,
        [Display(Name = "л")]
        L = 3,
    }
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
        public string Name { get; set; }
        public int Calories { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public WeightType PriceWeightType { get; set; }
        public WeightType WeightType { get; set; }
        public IList<ProductsDishes> ProductDishes { get; set; }

        //public override string ToString()
        //{
        //    return Id + " " + Name + " " + Calories + " " + Price + " " + Amount;
        //}
    }
}
