using CookBook.App.Resources.Texts;
using System.Globalization;

namespace CookBook.App.Converters;

public class UnitToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => UnitTexts.ResourceManager.GetString(value.ToString(), culture)
           ?? UnitTexts.Unknown;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}