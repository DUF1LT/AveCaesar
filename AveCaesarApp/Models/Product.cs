namespace AveCaesarApp.Models
{
    public enum WeightType
    {
        кг, л
    }
    public class Product
    {
        private int _id;
        private string _name;
        private int _calories;
        private int _price;
        private int _amount;
        private WeightType _weightType;

        public Product(int id, string name, int calories, int price, int amount, string weightType)
        {
           _id = id;
           _name = name;
           _calories = calories;
           _price = price;
           _amount = amount;
           if (weightType == "кг")
               _weightType = WeightType.кг;
           else if (weightType == "л")
               _weightType = WeightType.л;
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


        public WeightType WeightType
        {
            get => _weightType;
            set => _weightType = value;
        }

        //public override string ToString()
        //{
        //    return ID + " " + Name + " " + Calories + " " + Price + " " + Amount;
        //}
    }
}
