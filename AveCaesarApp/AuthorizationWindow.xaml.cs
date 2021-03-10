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
            LoginTextBox.Text = "Логин";
            LoginTextBox.FontWeight = FontWeights.Light;
            PasswordTextBox.Text = "Пароль";
            PasswordTextBox.FontWeight = FontWeights.Light;
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
                LoginTextBox.FontWeight = FontWeights.Bold;

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
                PasswordTextBox.FontWeight = FontWeights.Bold;

            }
        }
        #endregion

        private void LogInButton_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > 300 && Height <= 600)
            {
                LogInButton.FontSize = 18;
                LogInButton.MaxWidth = 350;
                LogInButtonBorder.Margin = new Thickness(110, 20, 110, 0);
                LogInLabel.FontSize = 23;
            }

            if (Height > 600 && Height <= 800)
            {
                LogInButton.MaxWidth = 450;
                LogInButton.FontSize = 20;
                LogInButtonBorder.Margin = new Thickness(170, 20, 170, 0);
                LogInLabel.FontSize = 26;


            }

            if (Height > 800 || this.WindowState == WindowState.Maximized)
            {
                LogInButton.FontSize = 23;
                LogInButton.MaxWidth = 600;
                LogInButtonBorder.Margin = new Thickness(250, 20, 250, 0);
                LogInLabel.FontSize = 30;


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

        private void LoginTextBox_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > 300 && Height <= 600)
            {
                LoginTextBox.FontSize = 18;
                LoginTextBox.MaxWidth = 350;
                LoginTextBoxBorder.Margin = new Thickness(60, 20, 60, 0);
            }

            if (Height > 600 && Height <= 800)
            {
                LoginTextBox.MaxWidth = 450;
                LoginTextBox.FontSize = 20;
                LoginTextBoxBorder.Margin = new Thickness(70, 20, 70, 0);

            }

            if (Height > 800 || this.WindowState == WindowState.Maximized)
            {
                LoginTextBox.FontSize = 23;
                LoginTextBox.MaxWidth = 600;
                LoginTextBoxBorder.Margin = new Thickness(160, 20, 160, 0);

            }
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
    }
}
