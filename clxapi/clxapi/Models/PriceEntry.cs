﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi
{
    public class PriceEntry
    {

        public float price { get; set; }
        public string gateway { get; set; }
        public string @operator { get; set; }
        public string expireDate { get; set; }

    }
}