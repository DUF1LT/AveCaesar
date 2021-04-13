using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using AveCaesarApp.Models;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Views
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
