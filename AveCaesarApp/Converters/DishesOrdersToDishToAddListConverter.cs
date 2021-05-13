using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using AveCaesarApp.Models;

namespace AveCaesarApp.Converters
{
    class DishesOrdersToDishToAddListConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IList<DishesOrders> dishesOrders)
            {
                var list = new List<DishToAdd>();
                foreach (var element in dishesOrders)
                {
                    
                    list.Add(new DishToAdd()
                    {
                        Dish = element.Dish,
                        Amount = element.DishAmount
                    });
                }

                return list;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
