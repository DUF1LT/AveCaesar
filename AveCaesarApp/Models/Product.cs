using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum WeightType
    {
        [Display(Name = "кг")]
        Kg,
        [Display(Name = "л")]
        L
    }
    public class Product : Item
    {
        

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
        public int Amount { get; set; }
        public WeightType WeightType { get; set; }

        //public override string ToString()
        //{
        //    return ID + " " + Name + " " + Calories + " " + Price + " " + Amount;
        //}
    }
}
