using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// Custom exception class inherits from Exception used to throw error from Clx API.
    /// </summary>
    public class ClxApiException : Exception
    {
        /// <summary>
        /// Property Containing Clx API internal Error Code.
        /// </summary>
        public int ClxErrorCode { get; set; }
        /// <summary>
        /// Property Containing Clx API internal Error message.
        /// </summary>
        public string ClxErrorMessage { get; set; }
        /// <summary>
        /// Constructor set message.
        /// </summary>
        /// <param name="message">Errormessage</param>
        public ClxApiException(string message)
        {
            ClxErrorMessage = message;
        }
        /// <summary>
        /// Constructor set message and code.
        /// </summary>
        /// <param name="message">Errormessage</param>
        /// <param name="code">ErrorCode</param>
        public ClxApiException(string message, int code)
        {
            ClxErrorMessage = message;
            ClxErrorCode = code;
        }
    }
}