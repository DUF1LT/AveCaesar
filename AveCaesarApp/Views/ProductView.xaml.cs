using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

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
            Regex regex = new Regex("^[0-9]{0,4}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);  
        }

        private void TextLengthValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z .а-яА-я]{0,30}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }

     
    }
}
