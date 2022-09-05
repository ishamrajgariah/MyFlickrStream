using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;

namespace FlickrGateway
{
    /// <summary>
    /// Class to interact with the service and return the response
    /// </summary>
    public class PublicFeedServiceHandler : IPublicFeedServiceHandler
    {
        private ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="PublicFeedServiceHandler"/>
        /// </summary>
        /// <param name="loggerInstance">The logger</param>
        public PublicFeedServiceHandler(ILogger loggerInstance)
        {
            logger = loggerInstance;
            Client = new HttpClient();
        }

        protected HttpClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the public stream from the given URL
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>public stream as string</returns>
        public async Task<string> GetPublicFeedStream(string url)
        {
            // Handle null url
            if (string.IsNullOrEmpty(url))
            {
                this.logger.LogError("Invalid url");
                throw new ArgumentException("Invalid url");
            }

            //Temporarily disabling the ssl validation for this assignment
            this.logger.LogWarning("Disabling client side SSL validation");
            ServicePointManager.ServerCertificateValidationCallback = delegate (
                Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    return (true);
                };

            
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            this.logger.LogDebug(string.Format("Sending request {0}", url));

            try
            {
                //send request and get the response
                var getStreamTask = Client.GetStringAsync(url);
                string result = await getStreamTask;
                return result;
            }
            catch (HttpRequestException exception)
            {
                this.logger.LogError(String.Format("The http request failed because of following reason {0}", exception.ToString()));
            }
            catch(Exception exception)
            {
                this.logger.LogError(string.Format("Exception occured {0}", exception.ToString()));
            }
            return String.Empty;
        }

    }

    public class PublicFeedServiceHandlerExtensionForTest : PublicFeedServiceHandler
    {
        public PublicFeedServiceHandlerExtensionForTest(ILogger logger, HttpClient client) : base(logger)
        {
            Client = client;
        }
    }
}
