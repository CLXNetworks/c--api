using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;

namespace clxapi
{
    public class ClxApi
    {
        // Constants to allow to configure what type of Request it is.
        private const string Get = "GET";
        private const string Post = "POST";
        private const string Put = "PUT";


        private ClxHttpClient _clxHttpClient;
        private string _baseUrl = "https://clx-aws.clxnetworks.com/api/";

        public ClxApi()
        {
            //Emty
        }

        /// <summary>
        /// Constructor, Inject Username and Password as Array
        /// </summary>
        /// <param name="Auth"></param>
        public ClxApi(String [] Auth)
        {
            _clxHttpClient = new ClxHttpClient(Auth);
        }

        /// <summary>
        /// Property used to change BaseUrl of application.
        /// </summary>
        public string BaseUrl 
        {
            set { _baseUrl = value; }
            get { return _baseUrl; }
        }

        /**************
        * OPERATORS
        **************/

        public JArray GetOperators()
        {
             _clxHttpClient.Url = String.Format(BaseUrl + "operator");
            var request = _clxHttpClient.Request();

            return request;
        }

    }
}