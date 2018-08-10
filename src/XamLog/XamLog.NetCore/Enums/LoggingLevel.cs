using System;
using System.Collections.Generic;
using System.Text;

namespace XamLog.Core.Enums
{
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
        /// Error (Bugs/Failed Code)
        /// </summary>
        Error,

        /// <summary>
        /// Fatal (Exceptions/Crashes)
        /// </summary>
        Fatal
    }
}
