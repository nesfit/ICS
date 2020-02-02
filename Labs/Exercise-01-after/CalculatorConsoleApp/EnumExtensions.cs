using System;
using System.ComponentModel;
using System.Linq;

namespace Exercise_01.CalculatorConsoleApp
{
    internal static class EnumExtensions
    {
        internal static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Any() ? attributes[0].Description : value.ToString();
        }
    }
}