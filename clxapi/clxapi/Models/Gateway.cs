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
        public int id { get; set; }
        public string name { get; set; }
        public string type {get; set;}
    }
}