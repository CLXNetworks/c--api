using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// Class to handle exception from Library
    /// </summary>
    public class ClxException : Exception
    {

        /// <summary>
        /// TODO: Implement Custom Exception class.
        /// </summary>
        /// <param name="message">Errormessage</param>
        public ClxException (string message)
            : base(message)
        {}
    }
}