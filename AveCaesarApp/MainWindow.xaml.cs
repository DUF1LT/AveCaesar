using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace AveCaesarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthorizationWindow authorizationWindow;
        public MainWindow(AuthorizationWindow aw)
        {
            InitializeComponent();
            authorizationWindow = aw;
        }

        private void MainWindowExitButton_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            authorizationWindow.Show();
            Close();
        }
    }
}
