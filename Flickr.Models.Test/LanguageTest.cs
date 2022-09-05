using System;
using FlickrStream.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flickr.Models.Test
{
    [TestClass]
    public class LanguageTest
    {
        [TestMethod]
        public void LanguageCode_English_ReturnsEnUs()
        {
            //Arrange
            Language language = new Language(LanguageName.English);

            //Assert
            Assert.AreEqual("en-us",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_German_ReturnsDeDe()
        {
            //Arrange
            Language language = new Language(LanguageName.German);

            //Assert
            Assert.AreEqual("de-de",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_Spanish_ReturnsEsUs()
        {
            //Arrange
            Language language = new Language(LanguageName.Spanish);

            //Assert
            Assert.AreEqual("es-us",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_French_ReturnsFrFr()
        {
            //Arrange
            Language language = new Language(LanguageName.French);

            //Assert
            Assert.AreEqual("fr-fr",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_Italian_ItIt()
        {
            //Arrange
            Language language = new Language(LanguageName.Italian);

            //Assert
            Assert.AreEqual("it-it",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_Korean_ReturnsKoKr()
        {
            //Arrange
            Language language = new Language(LanguageName.Korean);

            //Assert
            Assert.AreEqual("ko-kr",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_Portuguese_ReturnsPtBr()
        {
            //Arrange
            Language language = new Language(LanguageName.Portuguese);

            //Assert
            Assert.AreEqual("pt-br",language.LanguageCode);
        }

        [TestMethod]
        public void LanguageCode_Chinese_Returnszhhk()
        {
            //Arrange
            Language language = new Language(LanguageName.Chinese);

            //Assert
            Assert.AreEqual("zh-hk",language.LanguageCode);
        }
    }
}
