using CommunityToolkit.Maui.Converters;
using CookBook.App.Resources.Texts;
using CookBook.Common.Enums;
using System.Globalization;

namespace CookBook.App.Converters;

public class FoodTypeToStringConverter : BaseConverterOneWay<FoodType, string>
{
    public override string ConvertFrom(FoodType value, CultureInfo? culture)
        => FoodTypeTexts.ResourceManager.GetString(value.ToString(), culture)
           ?? FoodTypeTexts.None;

    public override string DefaultConvertReturnValue { get; set; } = FoodTypeTexts.None;
}