using CommunityToolkit.Maui.Converters;
using CookBook.App.Resources.Texts;
using CookBook.Common.Enums;
using System.Globalization;

namespace CookBook.App.Converters;

public class UnitToStringConverter : BaseConverterOneWay<Unit, string>
{
    public override string ConvertFrom(Unit value, CultureInfo? culture)
        => UnitTexts.ResourceManager.GetString(value.ToString(), culture)
           ?? UnitTexts.None;
    public override string DefaultConvertReturnValue { get; set; } = UnitTexts.None;
}