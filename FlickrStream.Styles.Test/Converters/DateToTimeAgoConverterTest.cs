using System;
using System.Globalization;
using FlickrStream.ControLibrary.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Styles.Test.Converters
{
    [TestClass]
    public class DateToTimeAgoConverterTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_NotImplementedTest()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            converter.ConvertBack(null, null, null, CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void Convert_Null_ReturnsEmptyString()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            var actual = converter.Convert(null, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(string.IsNullOrEmpty(actual.ToString()));
        }

        [TestMethod]
        public void Convert_InvalidDate_ReturnsEmptyString()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            var actual = converter.Convert("invalid", null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(string.IsNullOrEmpty(actual.ToString()));
        }

        [TestMethod]
        public void Convert_DateGreaterThan1YearLessThan2Years_ReturnsYearAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddYears(-1);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("year"));
            Assert.IsFalse(actual.ToString().Contains("years"));
        }

        [TestMethod]
        public void Convert_DateGreaterThan2Year_ReturnsYearsAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddYears(-2);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("years"));
            Assert.IsFalse(actual.ToString().Contains("year "));
        }

        [TestMethod]
        public void Convert_DateGreaterThan1MonthLessThan1Year_ReturnsMonthsAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddMonths(-2);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("months"));
            Assert.IsFalse(actual.ToString().Contains("month "));
        }

        [TestMethod]
        public void Convert_DateLessThan1Month_ReturnsMonthAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddMonths(-1);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("month"));
            Assert.IsFalse(actual.ToString().Contains("months"));
        }

        [TestMethod]
        public void Convert_DateGreaterThanFewDays_ReturnsDaysAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddDays(-5);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("days"));
            Assert.IsFalse(actual.ToString().Contains("day "));
        }

        [TestMethod]
        public void Convert_DateGreaterThan1Days_ReturnsDayAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddDays(-1);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("day"));
            Assert.IsFalse(actual.ToString().Contains("days"));
        }

        [TestMethod]
        public void Convert_DateLessThan1DayMoreThan1Hour_ReturnsHoursAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddHours(-2);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("hours"));
            Assert.IsFalse(actual.ToString().Contains("hour "));
        }

        [TestMethod]
        public void Convert_DateLessThan1Hour_ReturnsHourAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddHours(-1);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("hour"));
            Assert.IsFalse(actual.ToString().Contains("hours"));
        }

        [TestMethod]
        public void Convert_DateLessThan60mins_ReturnsMinsAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddMinutes(-55);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("minutes"));
            Assert.IsFalse(actual.ToString().Contains("minute "));
        }

        [TestMethod]
        public void Convert_DateLess1Min_ReturnsMinAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddMinutes(-1);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("minute"));
            Assert.IsFalse(actual.ToString().Contains("minutes"));
        }

        [TestMethod]
        public void Convert_DateLess11minMoreThan5Sec_ReturnsSecondsAgoFormat()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddSeconds(-10);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("seconds"));
        }

        [TestMethod]
        public void Convert_DateLessThan5Sec_ReturnsJustNow()
        {
            DateToTimeAgoConverter converter = new DateToTimeAgoConverter();
            DateTime testDateTime = DateTime.Now.AddSeconds(-5);
            var actual = converter.Convert(testDateTime, null, null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual.ToString().Contains("just now"));
        }
    }
}
