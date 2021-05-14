using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp.Converters
{
    class AddOrEditConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ItemOperationType operation)
            {
                switch (operation)
                {
                    case ItemOperationType.Add:
                        return "Добавить";
                    case ItemOperationType.Edit:
                        return "Подтвердить";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
