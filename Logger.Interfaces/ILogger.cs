using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Logger.Interfaces
{
    /// <summary>
    /// Interface for generating logs
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log error level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        void LogError(string logmessage);

        /// <summary>
        /// Log warning level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        void LogWarning(string logmessage);

        /// <summary>
        /// Log debug level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        void LogDebug(string logmessage);

        /// <summary>
        /// Log info level messages
        /// </summary>
        /// <param name="logmessage">The message</param>
        void LogInformation(string logmessage);
    }
}
