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
        public int? ClxErrorCode { get; set; }
        /// <summary>
        /// Property Containing Clx API internal Error message.
        /// </summary>
        public string ClxErrorMessage { get; set; }
        /// <summary>
        /// Property Containing Http statuscode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Constructor set message and code.
        /// </summary>
        /// <param name="clxErrorMessage">Errormessage</param>
        /// <param name="clxErrorCode">ErrorCode</param>
        /// <param name="statusCode">statusCode</param>
        public ClxApiException(string clxErrorMessage, int?  clxErrorCode, int statusCode)
        {
            ClxErrorMessage = clxErrorMessage;
            ClxErrorCode = clxErrorCode;
            StatusCode = statusCode;
        }



       
    }
}