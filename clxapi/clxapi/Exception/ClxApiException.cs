using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// TODO: Implement custom exception to handle api errors.
    /// </summary>
    public class ClxApiException : Exception
    {
        public int ClxErrorCode { get; set; }
        public string ClxErrorMessage { get; set; }
        /// <summary>
        /// TODO: Implement Custom Exception class.
        /// </summary>
        /// <param name="message">Errormessage</param>
        public ClxApiException(string message)
        {
            ClxErrorMessage = message;
        }

        public ClxApiException(string message, int code)
        {
            ClxErrorMessage = message;
            ClxErrorCode = code;
        }

    }
}