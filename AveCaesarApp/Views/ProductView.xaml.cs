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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{0,3}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);  
        }

        private void TextLengthValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^\\w{0,15}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }
    }
}
