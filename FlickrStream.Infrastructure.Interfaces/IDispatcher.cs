using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Infrastructure.Interfaces
{
    /// <summary>
    /// Acts a wrapper over inbuilt dispatcher
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Invokes the dispatcher
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        Task Dispatch(Delegate method, params object[] args);
       
    }
}
