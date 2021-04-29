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

namespace AveCaesarApp.UserControls
{
    /// <summary>
    /// Interaction logic for PasswordTextBox.xaml
    /// </summary>
    public partial class PasswordTextBox : UserControl
    {
        public static readonly RoutedEvent PasswordChangedEvent =
            EventManager.RegisterRoutedEvent("PasswordChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WatermarkTextBox));

        public string StoredPassword
        {
            get { return (string)GetValue(StoredPasswordProperty); }
            set { SetValue(StoredPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextBind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StoredPasswordProperty =
            DependencyProperty.Register("StoredPassword", typeof(string), typeof(PasswordTextBox), new PropertyMetadata(""));


        // Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...

        public PasswordTextBox()
        {
            InitializeComponent();
            WatermarkTextBlock.Text = "Пароль";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StoredPassword = WMTextBox.Text;
            RaiseEvent(new RoutedEventArgs(PasswordChangedEvent, this));
            if (WMTextBox.Text == "")
                WatermarkTextBlock.Text = "Пароль";
            else
                WatermarkTextBlock.Text = new string('●', WMTextBox.Text.Length);
        }

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(PasswordChangedEvent, value); }
            remove { RemoveHandler(PasswordChangedEvent, value); }
        }
    }
}
