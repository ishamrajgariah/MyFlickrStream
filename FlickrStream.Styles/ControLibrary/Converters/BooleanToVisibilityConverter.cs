using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FlickrStream.ControLibrary.Converters
{
    /// <summary>
    /// Converts bool to visibility
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or set if converter is inverted
        /// </summary>
        public bool IsInverted
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            try
            {
                bool isVisible = (bool) value;
                if (isVisible)
                {
                    if (IsInverted)
                    {
                        return Visibility.Collapsed;
                    }

                    return Visibility.Visible;
                }

                if (IsInverted)
                {
                    return Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
