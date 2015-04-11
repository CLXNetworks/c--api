using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clxapi
{
    /// <summary>
    /// Containts all paths toward ClxApi
    /// </summary>
    public class ClxSettings 
    {

        private string baseURI = "https://clx-aws.clxnetworks.com/api";
        public string BaseURI 
        {
            get { return baseURI; }
            set { baseURI = value; }
        }

        public const string OperatorPath = "/operator/";
        public const string GatewayPath = "/gateway/";
        public const string PricePath = "/price/";

        public const string DateParam = "/date=";

    }
}
