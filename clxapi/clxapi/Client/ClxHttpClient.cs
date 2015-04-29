using clxapi.Adapter;
using clxapi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Web;

namespace clxapi.Client
{
    /// <summary>
    /// Class to handle the Http request to Clx api.
    /// </summary>
    public class ClxHttpClient : IHttpClient
    {
        /// <summary>
        /// Property to set what adapter to use.
        /// </summary>
        public IHttpAdapter HttpAdapter{ get; set; }

        /// <summary>
        /// Property to set BaseURL.
        /// </summary>
        public string BaseURL{ get ; set; }

        /// <summary>
        ///  Constructor to initialize ClxHtttpClient: baseURL is url to Api.
        /// </summary>
        /// <example>Code example:
        /// <code> 
        /// var client = new ClxHttpClient("https://clx-aws.clxnetworks.com/api"); 
        /// </code>
        /// </example>
        /// <param name="baseURL">String with baseUrl to api.</param>
        public ClxHttpClient(string baseURL)
        {
            BaseURL = baseURL;
        }

        /// <summary>
        /// Handles Requests of type GET. Method concatinate BaseUrl resourse String and foward request to Excecute Method.
        /// </summary>
        /// <example>
        /// </example>
        /// <param name="url">resourse String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Get(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Get(fullUrl);
            return parseReponse(response);
        }

        /// <summary>
        /// Handles Requests of type POST. Not implemented
        /// </summary>
        /// <param name="url">resourse String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Post(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Post(fullUrl);
            return parseReponse(response);
        }

        /// <summary>
        /// Handles Requests of type PUT. Not implemented
        /// </summary>
        /// <param name="url">resourse String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Put(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Put(fullUrl);
            return parseReponse(response);
        }

        /// <summary>
        /// Private Method to parse ClxResponse into Jarray or Jobject.
        /// </summary>
        /// <param name="response"></param>
        /// <returns>Jarray or Jobject</returns>
        private dynamic parseReponse(ClxResponse response)
        {
            dynamic parsedBody;
            try
            {
                parsedBody = JValue.Parse(response.Body);
            }
            catch
            {
                throw new ClxException("Error when parsing Json");
            }
            // TODO: Implement exception handling with custom exceptions.
            if (response.StatusCode > 399)
            {
                string message = parsedBody.error.message;
                int code = parsedBody.error.code;
                // TODO: add errorcode from wrapper.
                throw new ClxApiException(message, code);
            }
            return parsedBody;          
        }
    }
}