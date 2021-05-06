using System.Windows;
using System.Windows.Controls;

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

        public static readonly DependencyProperty StoredPasswordProperty =
            DependencyProperty.Register("StoredPassword", typeof(string), typeof(PasswordTextBox), new PropertyMetadata(""));

        public static readonly RoutedEvent WatermarkChangedEvent =
            EventManager.RegisterRoutedEvent("WatermarkChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WatermarkTextBox));

        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("WatermarkProperty", typeof(string), typeof(PasswordTextBox), new PropertyMetadata(""));


        public PasswordTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StoredPassword = WMTextBox.Text;
            RaiseEvent(new RoutedEventArgs(PasswordChangedEvent, this));
            if (WMTextBox.Text == "")
                WatermarkTextBlock.Text = Watermark;
            else
                WatermarkTextBlock.Text = new string('●', WMTextBox.Text.Length);
        }

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(PasswordChangedEvent, value); }
            remove { RemoveHandler(PasswordChangedEvent, value); }
        }

        private void PasswordTextBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            WatermarkTextBlock.Text = Watermark;
            RaiseEvent(new RoutedEventArgs(WatermarkChangedEvent, this));
        }
    }
}
