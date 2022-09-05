using System;
using Flickr.Models.Models;
using FlickrStream.Logger.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlickrStream.Infrastructure.Test
{
    [TestClass]
    public class JsonDeserializerTest
    {
        private Mock<ILogger> logger;

        [TestInitialize]
        public void Initialize()
        {
            logger = new Mock<ILogger>();
        }

        [TestMethod]
        public void Deserialize_EmptyJson_ReturnsNull()
        {
            //Arrange
            JsonDeserializer deserializer = new JsonDeserializer(logger.Object);

            //Act
            var actual = deserializer.Deserialize(string.Empty);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Deserialize_NullJson_ReturnsNull()
        {
            //Arrange
            JsonDeserializer deserializer = new JsonDeserializer(logger.Object);

            //Act
            var actual = deserializer.Deserialize(null);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Deserialize_ValidJson_ReturnsRootObject()
        {
            //Arrange
            JsonDeserializer deserializer = new JsonDeserializer(logger.Object);

            //Act
            var actual = deserializer.Deserialize(Resources.DummyValidJson);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Root));   
        }

        [TestMethod]
        public void Deserialize_InvalidJson_ReturnsNull()
        {
            //Arrange
            JsonDeserializer deserializer = new JsonDeserializer(logger.Object);

            //Act
            var actual = deserializer.Deserialize(Resources.DummyInvalidJson);

            //Assert
            Assert.IsNull(actual);
        }
    }
}
