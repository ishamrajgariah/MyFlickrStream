using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Flickr.Models.Models;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;
using Newtonsoft.Json;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Class to deserialize JSON into object model
    /// </summary>
    public class JsonDeserializer : IDeserializer
    {
        private ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="JsonDeserializer"/>
        /// </summary>
        /// <param name="loggerInstance"></param>
        public JsonDeserializer(ILogger loggerInstance)
        {
            logger = loggerInstance;
        }

        /// <summary>
        /// Deserializes given json string to object model
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns></returns>
        public Root Deserialize(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Root>(json);
            }
            catch(Exception exception)
            {
                this.logger.LogError(String.Format("The json could not be deserialized because {0}", exception.ToString()));
                return null;
            }
        }
    }
}
