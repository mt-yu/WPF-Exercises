using System;
using System.Globalization;
using System.Windows.Data;

namespace Sample._7.Converters
{
    internal class CircleToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)(double.Parse(value.ToString()) * 10 / 36);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NullReferenceException();
        }
    }
}