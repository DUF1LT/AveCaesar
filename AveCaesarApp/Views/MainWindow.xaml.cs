using System.Windows;
using System.Windows.Input;

namespace AveCaesarApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthorizationWindow authorizationWindow;
        private ProductsWindow productsWindow;
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

        private void ProductsButtonBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            productsWindow = new ProductsWindow(this);
            productsWindow.Show();
            Hide();
            
        }

        private void CloseButton_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
