using System;
using System.Collections.Generic;
using System.Text;

namespace XamLog.Core.Private
{
    /// <summary>
    /// Log Writer: Handles creation & writing to the log file!
    /// </summary>
    interface ILogWriter
    {
        /// <summary>
        /// Writes a message to log files.
        /// </summary>
        /// <param name="message">Message.</param>
        void WriteToLogs(string message);

        /// <summary>
        /// Writes a message to log files, only called from App.cs when a fatal exception occurs
        /// </summary>
        /// <param name="message">Message.</param>
        void WriteFatalExceptionToLogs(string message);
    }
}
