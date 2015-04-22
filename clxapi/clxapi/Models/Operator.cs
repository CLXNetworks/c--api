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
        public string network { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string uniqueName { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string isoCountryCode { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string operationalState { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public string operationalStatDate { get; set; }
        /// <summary>
        /// Property for databinding.
        /// </summary>
        public int numberOfSubscribers { get; set; }
    }
}