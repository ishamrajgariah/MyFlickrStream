using System;
using System.Globalization;
using System.Windows.Data;

namespace FlickrStream.ControLibrary.Converters
{
    /// <summary>
    /// Inverts a bool
    /// </summary>
    public class InvertedBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            try
            {
                bool currentValue = (bool) value;
                return !currentValue;
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                bool currentValue = (bool)value;
                return !currentValue;
            }
            catch
            {
                return false;
            }
        }
    }
}
