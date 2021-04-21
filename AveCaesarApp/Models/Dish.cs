using System.ComponentModel;

namespace AveCaesarApp.Models
{
    public enum DishType
    {
        Rolls = 1,
        Sandwich,
        Soup,
        Bowl,
        Salad,
        Dessert,
        Beverages,
        Smoothie 
    }

    public class Dish : Item
    {
        public Dish(
            int id, 
            string name,
            string image, 
            int weight, 
            float price, 
            float proteins, 
            float fats, 
            float carbons,
            BindingList<Product> products,
            WeightType weightType, 
            DishType dishType) : base(id)
        {
            Name = name;
            Image = image;
            Weight = weight;
            Price = price;
            Proteins = proteins;
            Fats = fats;
            Carbons = carbons;
            Products = products;
            WeightType = weightType;
            DishType = dishType;
        }


        public string Name { get; set; }

        public string Image { get; set; }

        public int Weight { get; set; }

        public float Price { get; set; }

        public float Proteins { get; set; }

        public float Fats { get; set; }

        public float Carbons { get; set; }

        public BindingList<Product> Products { get; set; }

        public WeightType WeightType { get; set; }

        public DishType DishType { get; set; }
    }
}
