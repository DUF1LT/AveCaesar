using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace AveCaesarApp.Classes
{
    public enum WeightType
    {
        Kilograms, Liters
    }
    public class Product
    {
        private int _id;
        private string _name;
        private int _calories;
        private int _price;
        private int _amount;
        private WeightType _weightType;

        public Product(int id, string name, int calories, int price, int amount)
        {
            this._id = id;
            this._name = name;
            this._calories = calories;
            this._price = price;
            this._amount = amount;
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
        public int Calories
        {
            get => _calories;
            set => _calories = value;
        }

        public string CaloriesToString => Calories + " ккал";

        public int Price
        {
            get => _price;
            set => _price = value;
        }
        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        

        //public override string ToString()
        //{
        //    return ID + " " + Name + " " + Calories + " " + Price + " " + Amount;
        //}
    }
}
