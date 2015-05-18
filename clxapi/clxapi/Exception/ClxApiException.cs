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
        /// Constructor set message and code.
        /// </summary>
        /// <param name="clxErrorMessage">Errormessage</param>
        /// <param name="clxErrorCode">ErrorCode</param>
        public ClxApiException(string clxErrorMessage, int clxErrorCode)
        {
            ClxErrorMessage = clxErrorMessage;
            ClxErrorCode = clxErrorCode;
        }
    }
}