using System;
using System.Collections.Generic;
using System.Windows;
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

            ProductsList = new List<Product>
            {
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10),
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10),
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10),
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10),
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10),
                new Product(1, "Помидор", 25, 10, 10),
                new Product(2, "Помидор", 25, 10, 10)
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
