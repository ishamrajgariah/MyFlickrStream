using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Models.Models
{
    /// <summary>
    /// Model for Item
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Item
    {
        /// <summary>
        /// Gets or set title string
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or set link string
        /// </summary>
        public string link { get; set; }

        /// <summary>
        /// Gets or set media string
        /// </summary>
        public Media media { get; set; }

        /// <summary>
        /// Gets or set date taken
        /// </summary>
        public DateTime date_taken { get; set; }

        /// <summary>
        /// Gets or set description string
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or set published date
        /// </summary>
        public DateTime published { get; set; }

        /// <summary>
        /// Gets or set author string
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// Gets or set author_id string
        /// </summary>
        public string author_id { get; set; }

        /// <summary>
        /// Gets or set tags string
        /// </summary>
        public string tags { get; set; }
    }
}
