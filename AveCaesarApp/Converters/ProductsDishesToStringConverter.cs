using System;
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
    class ProductsDishesToStringConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<ProductsDishes> productsDishes)
            {
                return string.Join(", " ,productsDishes.Select(p => p.Product.Name + " - " + p.ProductAmount + " " + p.Product.WeightType.GetDisplayName()));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
