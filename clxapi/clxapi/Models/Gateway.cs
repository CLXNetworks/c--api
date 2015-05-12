using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// Model for databinding.
    /// </summary>
    public class Gateway
    {
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string type {get; set;}
        /// <summary>
        /// Method used to Serialize property values from Gateway.
        /// </summary>
        /// <returns>String of property values</returns>
        public string Stringyfy()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}