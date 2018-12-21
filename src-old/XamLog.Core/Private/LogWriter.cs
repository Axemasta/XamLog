using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using XamLog.Core.Enums;

namespace XamLog.Core.Private
{
    /// <summary>
    /// Log Writer: Handles creation & writing to the log file!
    /// </summary>
    class LogWriter : ILogWriter
    {
        #region Properties

        private string _className;

        #endregion Properties

        public LogWriter()
        {
            _className = this.GetType().Name;
        }

        #region Interface Methods

        /// <summary>
        /// Writes a message to log files.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteToLogs(string message)
        {
            LogMessage(message, LogType.Async);
        }

        /// <summary>
        /// Writes a message to log files, only called from App.cs when a fatal exception occurs
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteFatalExceptionToLogs(string message)
        {
            LogMessage(message, LogType.Sync);
        }

        #endregion Interface Methods

        #region - File Access Methods

        private async void LogMessage(string message, LogType logType)
        {
            string methodName = "LogMessage";
            string filePath = GetFilePath();

            bool file = CheckLogFileExists(filePath);

            if (file)
            {
                //Debug.WriteLine(String.Format("{0} - {1} - Log File Exists! Appending message to file.", _className, methodName));

                switch (logType)
                {
                    case LogType.Async:
                        await WriteToFileAsync(filePath, message);
                        break;

                    case LogType.Sync:
                        WriteToFile(filePath, message);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Debug.WriteLine(String.Format("{0} - {1} - Log File Doesn't Exist! Creating log file and appending message.", _className, methodName));

                if (CreateLogFile(filePath))
                {
                    switch (logType)
                    {
                        case LogType.Async:
                            await WriteToFileAsync(filePath, message);
                            break;

                        case LogType.Sync:
                            WriteToFile(filePath, message);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>The file path.</returns>
        private string GetFilePath()
        {
            string fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(fileDirectory, Constants.LogFileName);

            return filePath;
        }

        /// <summary>
        /// Checks the log file exists. Creates the file if it doesn't exist.
        /// </summary>
        /// <returns><c>true</c>, if log file exists was checked, <c>false</c> otherwise.</returns>
        /// <param name="filePath">File path.</param>
        private bool CheckLogFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Creates the log file.
        /// </summary>
        /// <returns><c>true</c>, if log file was created, <c>false</c> otherwise.</returns>
        /// <param name="filePath">File path.</param>
        private bool CreateLogFile(string filePath)
        {
            string methodName = "CreateLogFile";
            try
            {
                using (File.CreateText(filePath))

                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("{0} - {1} - ERROR: {2}", _className, methodName, ex.Message));
                return false;
            }
        }

        /// <summary>
        /// Accesses and writes to the log file syncronously.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <param name="message">Message.</param>
        private void WriteToFile(string filePath, string message)
        {
            string methodName = "WriteToFile";

            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    file.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("{0} - {1} - ERROR: {2}", _className, methodName, ex.Message));
            }
        }

        /// <summary>
        /// Accesses and writes to the log file asyncronously.
        /// </summary>
        /// <returns>The to file.</returns>
        /// <param name="filePath">File path.</param>
        /// <param name="message">Message.</param>
        private async Task WriteToFileAsync(string filePath, string message)
        {
            string methodName = "WriteToFile";

            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    await file.WriteLineAsync(message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("{0} - {1} - ERROR: {2}", _className, methodName, ex.Message));
            }
        }

        #endregion - File Access Methods

        /*

        #region Methods

        #region - Interface Methods

        /// <summary>
        /// Writes a message to log files.
        /// </summary>
        /// <param name="message">Message.</param>
        public async void WriteToLogs(string message)
        {
            string methodName = "WriteToLogs";
            string filePath = GetFilePath();

            bool file = CheckLogFileExists(filePath);

            if (file)
            {
                //Debug.WriteLine(String.Format("{0} - {1} - Log File Exists! Appending message to file.", _className, methodName));

                await WriteToFileAsync(filePath, message);
            }
            else
            {
                Debug.WriteLine(String.Format("{0} - {1} - Log File Doesn't Exist! Creating log file and appending message.", _className, methodName));

                if (CreateLogFile(filePath))
                {
                    await WriteToFileAsync(filePath, message);
                }
            }
        }

        /// <summary>
        /// Writes a message to log files, only called from App.cs when a fatal exception occurs
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteFatalExceptionToLogs(string message)
        {
            string methodName = "WriteFatalExceptionToLogs";
            string filePath = GetFilePath();

            bool fileExists = CheckLogFileExists(filePath);

            if (fileExists)
            {
                WriteToFile(filePath, message);
            }
            else
            {
                Debug.WriteLine(String.Format("{0} - {1} - Log File Doesn't Exist! Creating log file and appending message.", _className, methodName));

                if (CreateLogFile(filePath))
                {
                    WriteToFile(filePath, message);
                }
            }
        }

        #endregion - Interface Methods

        

        #endregion Methods
    */
    }
}