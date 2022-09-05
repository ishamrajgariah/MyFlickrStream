using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Models.Models;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Class to get the photo stream and return the adapted result in compatible format
    /// </summary>
    public class PhotoStreamBridge : IPhotoStreamBridge
    {
        private IPublicFeedServiceHandler publicFeedServiceHandler;
        private IDeserializer deserializer;
        private ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="PhotoStreamBridge"/>
        /// </summary>
        /// <param name="publicFeedServiceHandlerInstance">The service handler</param>
        /// <param name="deserializerInstance">The deserializer</param>
        /// <param name="loggerInstance">The logger</param>
        public PhotoStreamBridge(IPublicFeedServiceHandler publicFeedServiceHandlerInstance, IDeserializer deserializerInstance, ILogger loggerInstance)
        {
            this.publicFeedServiceHandler = publicFeedServiceHandlerInstance;
            this.deserializer = deserializerInstance;
            this.logger = loggerInstance;
        }

        /// <summary>
        /// Search options for getting the photostream
        /// </summary>
        public SearchOptions Options { get; set; }

        /// <summary>
        /// Gets the photo stream
        /// </summary>
        /// <returns>List of photos</returns>
        public async Task<List<Item>> GetPhotoStream()
        {
            //Build the url
            string url;
            if (this.Options != null)
            {
                url = UrlHelper.GetPublicFeedUrl(Options.Tags, Options.TagMode, Options.Lang, Options.IDs);
            }
            else
            {
                url = UrlHelper.GetPublicFeedUrl(string.Empty, string.Empty, string.Empty, string.Empty);
            }

            //get the response
            try
            {
                string responseString = await this.publicFeedServiceHandler.GetPublicFeedStream(url);

                if (string.IsNullOrEmpty(responseString))
                {
                    this.logger.LogError("Could not get a valid response from feed");
                
                }
                else
                {
                    //adapt the response
                    Root responseObject = deserializer.Deserialize(responseString);
                    if (responseObject != null)
                    {
                        return responseObject.items;
                    }
                }
            }
            catch (Exception e)
            {
                this.logger.LogError(String.Format("Invalid image response {0}", e));
            }

            return new List<Item>();
        }
    }
}
