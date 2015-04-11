using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace clxapi
{
    /// <summary>
    /// Model for databinding.
    /// </summary>
    public class Operator
    {
        public int id { get; set; }
        public string name { get; set; }
        public string network { get; set; }
        public string uniqueName { get; set; }
        public string isoCountryCode { get; set; }
        public string operationalState { get; set; }
        public string operationalStatDate { get; set; }
        public int numberOfSubscribers { get; set; }
    }
}