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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void SymbolValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text[0]) || ((TextBox)sender).Text.Length > 40;
        }

        private void LatinLettersValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[A-z0-9]+$");
            e.Handled = !regex.IsMatch(((TextBox) sender).Text + e.Text);
        }
    }
}
