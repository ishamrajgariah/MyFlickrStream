using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Helps to build URL
    /// </summary>
    public class UrlHelper 
    {
        private const string baseUrl = "https://api.flickr.com/services/feeds/photos_public.gne?";
        
        /// <summary>
        /// Creates a url using given parameters
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="tagMode"></param>
        /// <param name="lang"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GetPublicFeedUrl(string tags, string tagMode, string lang, string ids)
        {
            StringBuilder url = new StringBuilder(baseUrl);

            if(!string.IsNullOrEmpty(tags))
            {
                url.Append(string.Format("&tags={0}", tags));
            }

            if (!string.IsNullOrEmpty(tagMode))
            {
                url.Append(string.Format("&tagmode={0}", tagMode));
            }

            if (!string.IsNullOrEmpty(lang))
            {
                url.Append(string.Format("&lang={0}", lang));
            }

            if (!string.IsNullOrEmpty(ids))
            {
                if (ids.Contains(","))
                {
                    url.Append(string.Format("&ids={0}", ids));
                }
                else
                {
                    url.Append(string.Format("&id={0}", ids));
                }
            }

            //Append json format and no callback to get pure json
            url.Append("&format=json&nojsoncallback=?");
            return url.ToString();
        }
    }
}
