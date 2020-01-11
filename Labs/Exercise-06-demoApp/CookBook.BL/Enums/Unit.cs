using System.ComponentModel;
using CookBook.BL.Converters;

namespace CookBook.BL.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Unit
    {
        [Description("kg")]
        Kg,
        [Description("l")]
        L,
        [Description("ml")]
        Ml,
        [Description("g")]
        G,
        [Description("pieces")]
        Pieces,
        [Description("spoon")]
        Spoon
    }
}