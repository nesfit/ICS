using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Calculator.App;

internal static class EnumExtensions
{
    internal static string GetDescription(this Enum value)
    {
        //nullability - we know that the field has to exist, because we query the enum type by its value
        FieldInfo field = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Any() ? attributes[0].Description : value.ToString();
    }
}
