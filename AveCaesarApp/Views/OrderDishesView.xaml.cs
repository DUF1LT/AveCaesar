using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AveCaesarApp.Views
{
    /// <summary>
    /// Interaction logic for OrderDishesView.xaml
    /// </summary>
    public partial class OrderDishesView : UserControl
    {
        public OrderDishesView()
        {
            InitializeComponent();
        }
        private void VerticalScrollBar_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll =
                (sender as ListView).Parent as ScrollViewer;

            if (e.Delta < 0)
                scroll.LineDown();
            else
                scroll.LineUp();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{0,2}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }
    }
}
