﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Sample._7.Converters
{
    public class AngleToIsLargeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var angle = (double)value;
            return angle > 180;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}