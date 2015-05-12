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
    public class PriceEntry
    {
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public float price { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string gateway { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string @operator { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string expireDate { get; set; }
        /// <summary>
        /// Method used to Serialize property values from PriceEntry.
        /// </summary>
        /// <returns>String of property values</returns>
        public string Stringyfy()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}