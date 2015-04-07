using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;

namespace clxapi
{
    /// <summary>
    /// Masterclass, holds all Operators through requests are done, Make an instance of this class to acces the public operator methods.
    /// </summary>
    public class ClxApi
    {
        // Constants to allow to configure what type of Request it is.
        private const string Get = "GET";
        private const string Post = "POST";
        private const string Put = "PUT";


        private ClxHttpClient _clxHttpClient;
        private Settings _settings;
        private string _baseUrl = "https://clx-aws.clxnetworks.com/api/";

        /// <summary>
        /// Constructor, Initialize with credentials array, It will then setup all other dependendancies in project.
        /// </summary>
        /// <param name="Auth">Array with credentials</param>
        public ClxApi(String [] Auth)
        {
            _settings = new Settings();
            _clxHttpClient = new ClxHttpClient(Auth, _settings);        
        }

        /// <summary>
        /// Property to give possibilty to change baseurl of api.
        /// </summary>
        public string BaseUrl 
        {
            set { _baseUrl = value; }
            get { return _baseUrl; }
        }

        /**************
        * OPERATORS
        **************/
        /// <summary>
        /// Returns all operators from Clx api.
        /// </summary>
        /// <returns>JArray</returns>
        public JArray GetOperators()
        {
             _clxHttpClient.Url = String.Format(BaseUrl + _settings.operatorPath);
            var request = _clxHttpClient.Request();

            return request;
        }

    }
}