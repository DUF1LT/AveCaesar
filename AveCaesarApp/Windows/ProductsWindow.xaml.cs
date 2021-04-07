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
        private MainWindow mainWindow;
        private BindingList<Product> productsList = new BindingList<Product>();
        public ProductsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            productsList.Add(new Product("Помидор",25,10,10));
            ProductsDataGrid.ItemsSource = productsList;
        }

        private void Logo_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Show();
            Close();
        }


        private void ProductsWindow_OnClosed(object? sender, EventArgs e)
        {
            mainWindow.Show();
        }
    }
}
