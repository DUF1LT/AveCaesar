using System;
using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return enumVal.ToString();
        }
    }
}
