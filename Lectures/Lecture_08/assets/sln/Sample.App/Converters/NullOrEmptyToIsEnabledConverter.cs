using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace Sample.App.Converters
{
    public class NullOrEmptyToIsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}