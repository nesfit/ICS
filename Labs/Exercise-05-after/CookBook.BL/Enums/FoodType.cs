using System.ComponentModel;
using CookBook.BL.Converters;

namespace CookBook.BL.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FoodType
    {
        [Description("main dish")]
        MainDish,
        [Description("soup")]
        Soup,
        [Description("dessert")]
        Dessert
    }
}
