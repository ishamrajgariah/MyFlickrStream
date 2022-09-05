using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logger.Test
{
    [TestClass]
    public class LoggerTest
    {

        public Mock<ILog> log4NetLogger;

        [TestInitialize]
        public void Initialize()
        {
            log4NetLogger = new Mock<ILog>();
        }

        [TestMethod]
        public void LogDebugTest()
        {
            FlickrStream.Logger.Logger logger = new FlickrStream.Logger.Logger(log4NetLogger.Object);
            logger.LogDebug("testMessage");

            log4NetLogger.Verify(l => l.Debug(It.IsAny<object>()));
        }

        [TestMethod]
        public void LogErrorTest()
        {
            FlickrStream.Logger.Logger logger = new FlickrStream.Logger.Logger(log4NetLogger.Object);
            logger.LogError("testMessage");

            log4NetLogger.Verify(l => l.Error(It.IsAny<object>()));
        }

        [TestMethod]
        public void LogInformationTest()
        {
            FlickrStream.Logger.Logger logger = new FlickrStream.Logger.Logger(log4NetLogger.Object);
            logger.LogInformation("testMessage");

            log4NetLogger.Verify(l => l.Info(It.IsAny<object>()));
        }

        [TestMethod]
        public void LogWarningTest()
        {
            FlickrStream.Logger.Logger logger = new FlickrStream.Logger.Logger(log4NetLogger.Object);
            logger.LogWarning("testMessage");

            log4NetLogger.Verify(l => l.Warn(It.IsAny<object>()));
        }
    }
}
