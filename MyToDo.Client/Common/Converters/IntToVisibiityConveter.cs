using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MyToDo.Client.Common.Converters
{
    [ValueConversion(typeof(int), typeof(Visibility))]
    internal class IntToVisibiityConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result == 0)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && Enum.TryParse(value.ToString(), out Visibility result))
            {
                if (result == Visibility.Visible)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
