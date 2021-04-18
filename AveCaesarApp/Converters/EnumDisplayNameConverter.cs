using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using AveCaesarApp.Extensions;

namespace AveCaesarApp.Converters
{
    public class EnumDisplayNameConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Enum enumValue)
                return enumValue.GetDisplayName();
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}