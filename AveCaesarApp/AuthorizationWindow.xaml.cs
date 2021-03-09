using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace AveCaesarApp
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void SubTextBox_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Height > 300 && Height <= 600)
            {
                SubTextBox.FontSize = 18;
                SubTextBox.MaxWidth = 350;
            }

            if (Height > 600 && Height <= 800)
            {
                SubTextBox.MaxWidth = 450;
                SubTextBox.FontSize = 23;
            }

            if (Height > 800)
            {
                SubTextBox.FontSize = 30;
                SubTextBox.MaxWidth = 600;

            }
            if (this.WindowState == WindowState.Maximized)
            {
                SubTextBox.FontSize = 35;
                SubTextBox.MaxWidth = 600;
            }
        }
    }
}
