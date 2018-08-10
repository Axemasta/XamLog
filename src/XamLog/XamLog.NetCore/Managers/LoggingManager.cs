using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using XamLog.Core.Enums;
using XamLog.Core.Private;

namespace XamLog.Core.Managers
{
    /// <summary>
    /// Logging Manager- Provides an interface to output a message
    /// </summary>
    class LoggingManager : ILoggingManager
    {
        #region Properties

        #region  - Interfaces

        private readonly ILogWriter _logWriter;

        #endregion - Interfaces

        #region - Properties

        private const string _dateFormat = "dd/MM/yyyy HH:mm:ss";

        #endregion - Properties

        #endregion Properties

        public LoggingManager()
        {
            _logWriter = new LogWriter();
        }

        #region Methods

        #region Interface Methods

        /// <summary>
        /// Outputs message to console.
        /// </summary>
        /// <param name="message">Message.</param>
        public void OutputToConsole(string message)
        {
            Debug.WriteLine(message);
        }

        /// <summary>
        /// Outputs message to console. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        public void OutputToConsole(string className, string methodName, string message)
        {
            string formattedMessage = String.Format("{0} - {1} - {2}", className, methodName, message);
            Debug.WriteLine(formattedMessage);
        }

        /// <summary>
        /// Outputs to logs.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        public void OutputToLogs(string message, LoggingLevel level)
        {
            string formattedMessage = String.Format("[{0}] {1}", DateTime.Now.ToString(_dateFormat), message);
            _logWriter.WriteToLogs(formattedMessage);
        }

        /// <summary>
        /// Outputs message to logs. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        public void OutputToLogs(string className, string methodName, string message, LoggingLevel level)
        {
            string formattedMessage = String.Format("[{0}] {1} - {2} - {3}", DateTime.Now.ToString(_dateFormat), className, methodName, message);
            _logWriter.WriteToLogs(formattedMessage);
        }

        /// <summary>
        /// Outputs message to all.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        public void OutputToAll(string message, LoggingLevel level)
        {
            OutputToConsole(message);
            OutputToLogs(message, level);
        }

        /// <summary>
        /// Outputs message to all. Contains Class / Method data
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="message">Message.</param>
        /// <param name="level">Level.</param>
        public void OutputToAll(string className, string methodName, string message, LoggingLevel level)
        {
            OutputToConsole(className, methodName, message);
            OutputToLogs(className, methodName, message, level);
        }

        /// <summary>
        /// Writes a fatal error to the log file (only call this from app.cs)
        /// </summary>
        /// <param name="message"></param>       
        public void LogFatalException(string message)
        {
            _logWriter.WriteFatalExceptionToLogs(message);
        }

        #endregion Interface Methods

        #endregion Methods
    }
}
