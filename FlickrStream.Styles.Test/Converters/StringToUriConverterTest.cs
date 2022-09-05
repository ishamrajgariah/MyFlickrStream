using System;
using System.Globalization;
using FlickrStream.ControLibrary.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Styles.Test.Converters
{
    [TestClass]
    public class StringToUriConverterTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_NotImplementedTest()
        {
            StringToUriConverter converter = new StringToUriConverter();
            converter.ConvertBack(null, null, null, CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void Convert_Null_ReturnsNull()
        {
            StringToUriConverter converter = new StringToUriConverter();
            var actual = converter.Convert(null, null, null, CultureInfo.CurrentCulture);

            Assert.IsNull(actual);
        }

       
        [TestMethod]
        public void Convert_Empty_ReturnsNull()
        {
            StringToUriConverter converter = new StringToUriConverter();
            var actual = converter.Convert(string.Empty, null, null, CultureInfo.CurrentCulture);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Convert_Invalid_ReturnsNull()
        {
            StringToUriConverter converter = new StringToUriConverter();
            var actual = converter.Convert("invalid", null, null, CultureInfo.CurrentCulture);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Convert_Valid_ReturnsUriObject()
        {
            StringToUriConverter converter = new StringToUriConverter();
            var actual = converter.Convert("https://www.google.com", null, null, CultureInfo.CurrentCulture);

            Assert.IsInstanceOfType(actual, typeof(Uri));
        }

       
    }
}
