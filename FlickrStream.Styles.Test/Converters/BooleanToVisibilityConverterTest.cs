using System;
using System.Globalization;
using System.Windows;
using FlickrStream.ControLibrary.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Styles.Test.Converters
{
    [TestClass]
    public class BooleanToVisibilityConverterTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_NotImplementedTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            converter.ConvertBack(null, null, null, CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void Convert_Null_ReturnsCollapsed()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            var actual = converter.Convert(null, null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void Convert_NonBoolean_ReturnsCollapsed()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            var actual = converter.Convert("invalid", null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void Convert_True_ReturnsVisible()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            var actual = converter.Convert(true, null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Visible, actual);
        }

        [TestMethod]
        public void Convert_False_ReturnsCollapsed()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            var actual = converter.Convert(false, null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void Convert_True_IsInverted_ReturnsCollapsed()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            converter.IsInverted = true;
            var actual = converter.Convert(true, null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void Convert_false_IsInverted_ReturnsVisible()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();
            converter.IsInverted = true;
            var actual = converter.Convert(false, null, null, CultureInfo.CurrentCulture);

            Assert.AreEqual(Visibility.Visible, actual);
        }
    }
}
