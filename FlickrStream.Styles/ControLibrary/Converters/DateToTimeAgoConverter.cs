using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FlickrStream.ControLibrary.Converters
{
    /// <summary>
    /// Converts date time to Time ago
    /// </summary>
    public class DateToTimeAgoConverter : IValueConverter
    {
        private const int DaysInYear = 365;
        private const int DaysInMonth = 31;
        private const int MinTimeFromUploadInSec = 5;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                DateTime dateTime = (DateTime) value;

                TimeSpan span = DateTime.Now - dateTime;
                if (span.Days >= DaysInYear)
                {
                    int years = (span.Days / DaysInYear);
                    if (span.Days % DaysInYear != 0)
                    {
                        years += 1;

                    }

                    return String.Format("{0} {1} ago", years, years == 1 ? "year" : "years");

                }

                if (span.Days >= DaysInMonth)
                {
                    int months = (span.Days / DaysInMonth);
                    if (span.Days % DaysInMonth != 0)
                    {
                        months += 1;
                    }

                    return String.Format("{0} {1} ago", months, months == 1 ? "month" : "months");
                }

                if (span.Days > 0)
                {
                    return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");
                }

                if (span.Hours > 0)
                {
                    return String.Format("{0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");
                }

                if (span.Minutes > 0)
                {
                    return String.Format("{0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
                }

                if (span.Seconds > MinTimeFromUploadInSec)
                {
                    return String.Format("{0} seconds ago", span.Seconds);
                }

                if (span.Seconds <= MinTimeFromUploadInSec)
                {
                    return "just now";
                }
            }
            catch (Exception exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
