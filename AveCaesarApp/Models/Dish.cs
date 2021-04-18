using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AveCaesarApp.Models
{
    public enum DishType
    {
        Rolls, Sandwich, Soup, Bowl, Salad, Dessert, Beverages, Smoothie 
    }
    public class Dish
    {
        private int _id;
        private string _name;
        private string _image;
        private int _weight;
        private float _price;
        private float _proteins;
        private float _fats;
        private float _carbons;
        private WeightType _weightType;
        private DishType _dishType;

        public Dish(int id, string name, string image, int weight, float price, float proteins, float fats, float carbons, WeightType weightType, DishType dishType)
        {
            _id = id;
            _name = name;
            _image = image;
            _weight = weight;
            _price = price;
            _proteins = proteins;
            _fats = fats;
            _carbons = carbons;
            _weightType = weightType;
            _dishType = dishType;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Image
        {
            get => _image;
            set => _image = value;
        }

        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }

        public float Price
        {
            get => _price;
            set => _price = value;
        }

        public float Proteins
        {
            get => _proteins;
            set => _proteins = value;
        }

        public float Fats
        {
            get => _fats;
            set => _fats = value;
        }

        public float Carbons
        {
            get => _carbons;
            set => _carbons = value;
        }

        public WeightType WeightType
        {
            get => _weightType;
            set => _weightType = value;
        }

        public DishType DishType
        {
            get => _dishType;
            set => _dishType = value;
        }
    }
}
