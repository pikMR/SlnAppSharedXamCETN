using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppCETN.Shared
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (char)value;

            switch (stringValue)
            {
                case 'M':
                    return Color.FromRgb(217, 179, 255);
                case 'H':
                    return Color.FromRgb(153, 187, 255);
                default:
                    return Color.Orange;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
