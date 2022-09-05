using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using FlickrStream.Infrastructure.Interfaces;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Wrapper over inbuilt dispatcher
    /// </summary>
    public class ApplicationDispatcher : IDispatcher
    {
        public async Task Dispatch(Delegate method, params object[] args)
        {
           await UnderlyingDispatcher.BeginInvoke(method, args);
        }

        /// <summary>
        /// The actual dispatcher
        /// </summary>
        private Dispatcher UnderlyingDispatcher
        {
            get
            {
                return Dispatcher.CurrentDispatcher;
            }
        }
    }
}
