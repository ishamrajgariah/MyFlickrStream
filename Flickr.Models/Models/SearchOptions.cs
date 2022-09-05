using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Models.Models
{
    /// <summary>
    /// Class to handle different search options
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SearchOptions
    {
        /// <summary>
        /// Gets or sets Tags option
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets TagMode option
        /// </summary>
        public string TagMode { get; set; }

        /// <summary>
        /// Gets or sets Lang option
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// Gets or sets IDs option
        /// </summary>
        public string IDs { get; set; }
    }
}
