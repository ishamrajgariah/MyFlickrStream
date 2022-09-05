using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Models.Models;

namespace FlickrStream.Infrastructure.Interfaces
{
    /// <summary>
    /// Gets and Adapts the response from feed
    /// </summary>
    public interface IPhotoStreamBridge
    {
        /// <summary>
        /// The search options
        /// </summary>
        SearchOptions Options { get; set; }

        /// <summary>
        /// Gets the adapted photo stream
        /// </summary>
        /// <returns></returns>
        Task<List<Item>> GetPhotoStream();
    }
}
