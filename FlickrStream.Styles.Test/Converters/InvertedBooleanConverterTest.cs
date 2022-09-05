using System;
using System.Globalization;
using FlickrStream.ControLibrary.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Styles.Test.Converters
{
    [TestClass]
    public class InvertedBooleanConverterTest
    {
        [TestMethod]
        public void Convert_null_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ConvertBack_null_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.ConvertBack(null, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ConvertBack_InvalidValue_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.ConvertBack("invalid", typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Convert_InvalidValue_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.Convert("invalid", typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Convert_True_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Convert_False_ReturnsTrue()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ConvertBack_True_ReturnsFalse()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.ConvertBack(true, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void ConvertBack_False_ReturnsTrue()
        {
            InvertedBooleanConverter converter = new InvertedBooleanConverter();
            bool actual = (bool)converter.ConvertBack(false, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.IsTrue(actual);
        }
    }
}
