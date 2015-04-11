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

        public float price { get; set; }
        public string gateway { get; set; }
        public string @operator { get; set; }
        public string expireDate { get; set; }

    }
}