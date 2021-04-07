using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace AveCaesarApp.Classes
{
    class Product
    {
        private string name;
        private int calories;
        private int price;
        private int amount;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Calories
        {
            get => calories;
            set => calories = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }
        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public Product(string name, int calories, int price, int amount)
        {
            this.name = name;
            this.calories = calories;
            this.price = price;
            this.amount = amount;
        }

        public override string ToString()
        {
            return Name + " " + Calories + " " + Price + " " + Amount;
        }
    }
}
