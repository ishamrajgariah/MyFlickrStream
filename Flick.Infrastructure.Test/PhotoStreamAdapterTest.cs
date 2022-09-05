using System;
using System.Threading.Tasks;
using Flickr.Models.Models;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlickrStream.Infrastructure.Test
{
    [TestClass]
    public class PhotoStreamAdapterTest
    {
        private Mock<IPublicFeedServiceHandler> publicFeedServiceHandler;
        private Mock<IDeserializer> deserializer;
        private Mock<ILogger> logger;

        [TestInitialize]
        public void Initialize()
        {
            publicFeedServiceHandler = new Mock<IPublicFeedServiceHandler>();
            deserializer = new Mock<IDeserializer>();
            logger = new Mock<ILogger>();
        }

        [TestMethod]
        public async Task GetPhotoStream_SearchOptionsNull_ValidJsonResponse_ReturnsValidItemList()
        {
            //Arrange
            publicFeedServiceHandler.Setup(p => p.GetPublicFeedStream(It.IsAny<string>()))
                .ReturnsAsync(Resources.DummyValidJson);
            PhotoStreamBridge adapter = new PhotoStreamBridge(publicFeedServiceHandler.Object, 
                new JsonDeserializer(logger.Object), logger.Object);
            adapter.Options = null;

            //Act
            var itemList = await adapter.GetPhotoStream();

            //Assert
            Assert.AreEqual(2, itemList.Count);
        }

        [TestMethod]
        public async Task GetPhotoStream_WithSearchOptions_ValidJsonResponse_ReturnsValidItemList()
        {
            //Arrange
            publicFeedServiceHandler.Setup(p => p.GetPublicFeedStream(It.IsAny<string>()))
                .ReturnsAsync(Resources.DummyValidJson);
            PhotoStreamBridge adapter = new PhotoStreamBridge(publicFeedServiceHandler.Object,
                new JsonDeserializer(logger.Object), logger.Object);
            adapter.Options = new SearchOptions()
            {
                Tags = "test",
                IDs = "test",
                Lang = "en-us",
                TagMode = "all"
            };

            //Act
            var itemList = await adapter.GetPhotoStream();

            //Assert
            Assert.AreEqual(2, itemList.Count);
        }

        [TestMethod]
        public async Task GetPhotoStream_WithSearchOptions_InValidJsonResponse_ReturnsEmptyItemList()
        {
            //Arrange
            publicFeedServiceHandler.Setup(p => p.GetPublicFeedStream(It.IsAny<string>()))
                .ReturnsAsync(Resources.DummyInvalidJson);
            PhotoStreamBridge adapter = new PhotoStreamBridge(publicFeedServiceHandler.Object,
                new JsonDeserializer(logger.Object), logger.Object);
            adapter.Options = new SearchOptions()
            {
                Tags = "test",
                IDs = "test",
                Lang = "en-us",
                TagMode = "all"
            };

            //Act
            var itemList = await adapter.GetPhotoStream();

            //Assert
            Assert.AreEqual(0, itemList.Count);
        }
    }
}
