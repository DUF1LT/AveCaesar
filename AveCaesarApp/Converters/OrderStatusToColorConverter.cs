using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using AveCaesarApp.Extensions;
using AveCaesarApp.Models;

namespace AveCaesarApp.Converters
{
    public class OrderStatusToColorConverter : MarkupExtension,  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IEnumerable<OrderStatus> statuses)
            {
                var comboboxItems = new List<ComboBoxItem>(statuses.Count());
                foreach (var status in statuses)
                {
                    var item = new ComboBoxItem();
                    item.Content = status.GetDisplayName();
                    item.Background = Brushes.Green;
                    comboboxItems.Add(item);
                }

                return comboboxItems;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
