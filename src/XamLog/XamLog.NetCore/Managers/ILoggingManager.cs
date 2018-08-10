using System;
using System.Collections.Generic;
using System.Text;

using XamLog.Core.Enums;

namespace XamLog.Core.Managers
{
    interface ILoggingManager
    {
        /// <summary>
        /// Outputs message to console.
        /// </summary>
        /// <param name="message">Message.</param>
        void OutputToConsole(string message);

        /// <summary>
        /// Outputs message to console. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        void OutputToConsole(string className, string methodName, string message);

        /// <summary>
        /// Outputs to logs.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        void OutputToLogs(string message, LoggingLevel level);

        /// <summary>
        /// Outputs message to logs. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        void OutputToLogs(string className, string methodName, string message, LoggingLevel level);

        /// <summary>
        /// Outputs message to all.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        void OutputToAll(string message, LoggingLevel level);

        /// <summary>
        /// Outputs message to all. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        void OutputToAll(string className, string methodName, string message, LoggingLevel level);

        /// <summary>
        /// Writes a fatal error to the log file (only call this from app.cs)
        /// </summary>
        /// <param name="message"></param>
        void LogFatalException(string message);
    }
}
