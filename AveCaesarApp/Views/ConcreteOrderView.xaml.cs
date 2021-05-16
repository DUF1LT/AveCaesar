using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AveCaesarApp.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class ConcreteOrderView : UserControl
    {
        public ConcreteOrderView()
        {
            InitializeComponent();
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
        private void ItemsList_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ItemsList.SelectedItem = null;
        }
    }
}
