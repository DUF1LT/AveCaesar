using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using AveCaesarApp.Models;

namespace AveCaesarApp.Converters
{
    class ProductsListToStringConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
           return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList productsList)
            {
                string result = string.Empty;
                foreach (Product product in productsList)
                {
                    result += product.Name.ToLower() + ", ";
                }

                result = result.Remove(result.Length - 2, 2);
                return result;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
