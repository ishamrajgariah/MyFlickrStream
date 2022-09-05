using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Class to expose the DI container for IOC
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DIContainer
    {
        /// <summary>
        /// Gets and set the unity container
        /// </summary>
        public static IUnityContainer UnityContainer { get; set; }
    }
}
