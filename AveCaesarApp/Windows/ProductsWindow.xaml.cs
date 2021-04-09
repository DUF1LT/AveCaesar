using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AveCaesarApp.Classes;

namespace AveCaesarApp
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private MainWindow _mainWindow;
        private List<Product> _productsList;
        public ProductsWindow(MainWindow mainWindow)
        {
            InitializeComponent();


            this._mainWindow = mainWindow;

            _productsList = new List<Product>();

            _productsList.Add(new Product(1,"Помидор",25,10,10));
            _productsList.Add(new Product(2,"Помидор", 25, 10, 10));
            _productsList.Add(new Product(1, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(2, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(1, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(2, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(1, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(2, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(1, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(2, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(1, "Помидор", 25, 10, 10));
            _productsList.Add(new Product(2, "Помидор", 25, 10, 10));

        }

        public List<Product> ProductsList
        {
            get => _productsList;
        }

        private void Logo_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.Show();
            Close();
        }


        private void ProductsWindow_OnClosed(object? sender, EventArgs e)
        {
            _mainWindow.Show();
        }
    }
}
