using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AveCaesarApp.Classes;

namespace AveCaesarApp.Windows
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private MainWindow _mainWindow;

        public ProductsWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this._mainWindow = mainWindow;

            ProductsList = new BindingList<Product>()
            {
                new Product(1, "Помидор", 25, 10, 10, "кг"),
                new Product(2, "Помидор", 25, 10, 10, "кг"),
                new Product(3, "Масло", 25, 10, 10, "л" ),
                new Product(2, "Помидор", 25, 10, 10, "кг"),
                new Product(1, "Помидор", 25, 10, 10, "кг"),
                new Product(2, "Помидор", 25, 10, 10, "кг"),
                new Product(2, "Помидор", 25, 10, 10, "кг"),
                new Product(2, "Помидор", 25, 10, 10, "кг"),


            };

            DataContext = this;
        }

        public IList<Product> ProductsList { get; }

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
