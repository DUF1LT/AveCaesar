using System;
using System.Windows;
using System.Windows.Input;

namespace AveCaesarApp.Views
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            LoginTextBox.Text = "Логин";
            LoginTextBox.FontWeight = FontWeights.Light;
            PasswordTextBox.Text = "Пароль";
            PasswordTextBox.FontWeight = FontWeights.Light;
        }

        private void AuthorizationStackPanel_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > 300 && Height <= 600)
            {
                AuthorizationStackPanel.Margin = new Thickness(30, 0, 0, 0);
            }
            if (Height > 800 || this.WindowState == WindowState.Maximized)
            {
                AuthorizationStackPanel.Margin = new Thickness(60, 60, 0, 0);
            }

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

            if (Height > 800 || this.WindowState == WindowState.Maximized)
            {
                SubTextBox.FontSize = 30;
                SubTextBox.MaxWidth = 600;
            }
           
        }

        #region LoginTextBox

        private void LoginTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "Логин")
            {
                LoginTextBox.Text = "";
                LoginTextBox.FontWeight = FontWeights.Regular;

            }
        }

        private void LoginTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginTextBox.Text = "Логин";
                LoginTextBox.FontWeight = FontWeights.Light;

            }
        }
        

       
        #endregion

        #region PasswordTextBox

        private void PasswordTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Пароль";
                PasswordTextBox.FontWeight = FontWeights.Light;

            }
        }

        private void PasswordTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == "Пароль")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.FontWeight = FontWeights.Regular;

            }
        }

        private void PasswordTextBox_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > 300 && Height <= 600)
            {
                PasswordTextBox.FontSize = 18;
                PasswordTextBox.MaxWidth = 350;
                PasswordTextBoxBorder.Margin = new Thickness(60, 20, 60, 0);
            }

            if (Height > 600 && Height <= 800)
            {
                PasswordTextBox.MaxWidth = 450;
                PasswordTextBox.FontSize = 20;
                PasswordTextBoxBorder.Margin = new Thickness(70, 20, 70, 0);

            }

            if (Height > 800 || this.WindowState == WindowState.Maximized)
            {
                PasswordTextBox.FontSize = 23;
                PasswordTextBox.MaxWidth = 600;
                PasswordTextBoxBorder.Margin = new Thickness(160, 20, 160, 0);

            }
        }
        #endregion


        private void LogInButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(this);
            mw.Show();
            Hide();
        }

        private void AuthorizationWindow_OnClosed(object? sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseButton_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           Application.Current.Shutdown();
        }
    }
}
