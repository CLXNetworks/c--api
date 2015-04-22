using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// Class with properties to return response data.
    /// </summary>
    public class ClxResponse
    {
        /// <summary>
        /// Property: Contains HttpStatuscode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Property: Contains header values.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Property: Contains body values.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Property: Contains errormessage.
        /// </summary>
        public string Error { get; set; }
    }
}