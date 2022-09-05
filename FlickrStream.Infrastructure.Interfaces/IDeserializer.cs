using Flickr.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Infrastructure.Interfaces
{
    /// <summary>
    /// Defines the deserializer for string response
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Deseriazes the string response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Root Deserialize(string response);
    }
}
