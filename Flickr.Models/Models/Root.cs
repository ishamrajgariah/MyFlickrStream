using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Models.Models
{
    /// <summary>
    /// Root
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Root
    {
        /// <summary>
        /// Gets or sets title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets link
        /// </summary>
        public string link { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets modified date
        /// </summary>
        public DateTime modified { get; set; }

        /// <summary>
        /// Gets or sets generator
        /// </summary>
        public string generator { get; set; }

        /// <summary>
        /// Gets or sets items list
        /// </summary>
        public List<Item> items { get; set; }
    }
}
