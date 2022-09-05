using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Infrastructure.Interfaces
{
    /// <summary>
    /// Handles the request to flick public feed
    /// </summary>
    public interface IPublicFeedServiceHandler
    {
        /// <summary>
        /// Gets the feed stream from the given url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<string> GetPublicFeedStream(string url);

       
    }
}
