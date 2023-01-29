using CommunityToolkit.Maui.Converters;
using CookBook.Common.Enums;
using System.Globalization;

namespace CookBook.App.Converters;

public class FoodTypeToColorConverter : BaseConverterOneWay<FoodType, Color>
{
    public override Color ConvertFrom(FoodType value, CultureInfo? culture)
        => ((Application.Current?.Resources.TryGetValue($"{value}FoodTypeColor", out var resource) is true)
            && (resource is Color color))
            ? color
            : Colors.Transparent;

    public override Color DefaultConvertReturnValue { get; set; } = Colors.Transparent;
}