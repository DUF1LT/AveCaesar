using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using AveCaesarApp.Extensions;
using AveCaesarApp.Models;

namespace AveCaesarApp.Converters
{
    class ProductsToAddListToStringConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
           return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<ProductToAdd> productsList)
            {
                return string.Join(", ", productsList.Select(el => el.Product.Name + " - " + el.Amount + " " + el.Product.WeightType.GetDisplayName()));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
