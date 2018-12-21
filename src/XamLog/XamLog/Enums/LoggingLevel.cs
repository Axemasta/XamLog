using System;
using System.Collections.Generic;
using System.Text;

namespace XamLog.Enums
{
    /// <summary>
    /// Logging Level. The available levels to log a message.
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// Info (Runtime Info)
        /// </summary>
        Info,

        /// <summary>
        /// Debug (Initialisers/Non Issues)
        /// </summary>
        Debug,

        /// <summary>
        /// Warn (Unexpected errors)
        /// </summary>
        Warn,

        /// <summary>
        /// Error (Bugs/Failed Code)
        /// </summary>
        Error,

        /// <summary>
        /// Fatal (Exceptions/Crashes)
        /// </summary>
        Fatal
    }
}
