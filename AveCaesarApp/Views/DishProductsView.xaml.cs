using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace AveCaesarApp.Views
{
    /// <summary>
    /// Interaction logic for DishProductsAddView.xaml
    /// </summary>
    public partial class DishProductsView : UserControl
    {
        public DishProductsView()
        {
            InitializeComponent();
        }

      
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{0,4}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
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

    }
}
