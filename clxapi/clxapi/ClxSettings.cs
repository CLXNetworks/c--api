using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clxapi
{
    /// <summary>
    /// Containts all paths and params toward Clx Api
    /// </summary>
    public class ClxSettings 
    {

        private string baseURI = "https://clx-aws.clxnetworks.com/api";

        /// <summary>
        /// Property change baseURI
        /// </summary>
        public string BaseURI 
        {
            get { return baseURI; }
            set { baseURI = value; }
        }
        /// <summary>
        /// Path to operator toward Clx api.
        /// </summary>
        public const string OperatorPath = "/operator/";

        /// <summary>
        /// Path to gateway toward Clx api.
        /// </summary>
        public const string GatewayPath = "/gateway/";

        /// <summary>
        /// Path to price toward Clx api.
        /// </summary>
        public const string PricePath = "/price/";

        /// <summary>
        /// Param for date toward Clx api..
        /// </summary>
        public const string DateParam = "/date=";

    }
}
