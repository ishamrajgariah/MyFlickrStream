using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace FlickrGateway.Test
{
    [TestClass]
    public class PublicFeedServiceHandlerTest
    {
        private Mock<ILogger> logger;

        [TestInitialize]
        public void Initialize()
        {
            logger = new Mock<ILogger>();
            logger.Setup(l => l.LogError(It.IsAny<string>()));
            logger.Setup(l => l.LogWarning(It.IsAny<string>()));
            logger.Setup(l => l.LogDebug(It.IsAny<string>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetPublicFeedStream_Null_ThrowsArgumentException()
        {
            //Arrange
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandler(logger.Object);

            //Act
            await feedServiceHandler.GetPublicFeedStream(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetPublicFeedStream_EmptyString_ThrowsArgumentException()
        {
            //Arrange
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandler(logger.Object);

            //Act
            await feedServiceHandler.GetPublicFeedStream(string.Empty);
        }

        [TestMethod]
        public async Task GetPublicFeedStream_HttpClientThrowsHttpRequestException_ReturnsEmptyString()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
           
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                                ItExpr.IsAny<CancellationToken>())
                                .Throws<HttpRequestException>();
            
            var httpClient = new HttpClient(handlerMock.Object);
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandlerExtensionForTest(logger.Object, httpClient);

            //Act
            string actual = await feedServiceHandler.GetPublicFeedStream("TestUrl");

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod]
        public async Task GetPublicFeedStream_HttpClientReturns404_ReturnsEmptyString()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                
            };
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                                ItExpr.IsAny<CancellationToken>())
                                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandlerExtensionForTest(logger.Object, httpClient);

            //Act
            string actual = await feedServiceHandler.GetPublicFeedStream("TestUrl");

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod]
        public async Task GetPublicFeedStream_HttpClientReturnsGenericException_ReturnsEmptyString()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
           
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws<Exception>();
            var httpClient = new HttpClient(handlerMock.Object);
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandlerExtensionForTest(logger.Object, httpClient);

            //Act
            string actual = await feedServiceHandler.GetPublicFeedStream("TestUrl");

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod]
        public async Task GetPublicFeedStream_HttpClientReturnsOk_ReturnsResponseString()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            string testResponse = "{testResponse}";
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(testResponse)
            };
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            PublicFeedServiceHandler feedServiceHandler = new PublicFeedServiceHandlerExtensionForTest(logger.Object, httpClient);

            //Act
            string actual = await feedServiceHandler.GetPublicFeedStream("https://www.google.com");

            //Assert
            Assert.AreEqual(actual, testResponse);
        }

    }
}
