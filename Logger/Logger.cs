using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrStream.Logger.Interfaces;
using FlickrStream.Infrastructure;


namespace FlickrStream.Logger
{
    /// <summary>
    /// Logger using Log4net library
    /// </summary>
    public class Logger : ILogger
    {
        private static ILog log4NetLogger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log4netInstance">The log4net instance which does the actual logging</param>
        public Logger(ILog log4netInstance)
        {
            log4NetLogger = log4netInstance;
        }

        /// <summary>
        /// Log debug level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        public void LogDebug(string logmessage)
        {
            log4NetLogger.Debug(logmessage);
        }

        /// <summary>
        /// Log error level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        public void LogError(string logmessage)
        {
            log4NetLogger.Error(logmessage);
        }

        /// <summary>
        /// Log info level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        public void LogInformation(string logmessage)
        {
            log4NetLogger.Info(logmessage);
        }

        /// <summary>
        /// Log warning level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        public void LogWarning(string logmessage)
        {
            log4NetLogger.Warn(logmessage);
        }
    }
}
