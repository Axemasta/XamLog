using System;
using System.Collections.Generic;
using System.Text;

namespace XamLog.Enums
{
    /// <summary>
    /// Log Type. The way in which the logging methods are invoked, ie synchronously or asynchronously.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Synchronously, these methods will be invoked synchronously. Suitable when the app crashes and the log methods need to be invoked without much care for dependancy injection.
        /// </summary>
        Sync,

        /// <summary>
        /// Asynchronously, these methods will be invoked synchronously. This is the recommended way of invoking the logging methods.
        /// </summary>
        Async
    }
}
