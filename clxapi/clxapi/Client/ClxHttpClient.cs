using clxapi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Web;

namespace clxapi
{
    /// <summary>
    /// Class to handle the Http request to Clx api.
    /// </summary>
    public class ClxHttpClient : IHttpClient 
    {
        private string [] _auth;
        private ClxSettings _settings;

        /// <summary>
        ///  Constructor to initialize ClxHtttpClient: Auth is username/password and settings is api routes of Clx api.
        /// </summary>
        /// <param name="auth">Array with username/password to api</param>
        /// <param name="settings">Dependency injection of Clx api routes</param>
        public ClxHttpClient(string [] auth, ClxSettings settings)
        {
            _auth = auth;
            _settings = settings;
        }

        /// <summary>
        /// Handles Requests of type GET.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Get(String url)
        {
            return Request("GET", url);
        }

        /// <summary>
        /// Handles Requests of type POST.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Post(String url)
        {
            return Request("POST", url);
        }

        /// <summary>
        /// Handles Requests of type PUT.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Put(String url)
        {
            return Request("PUT", url);
        }

        /// <summary>
        /// Handles all requests to api.
        /// </summary>
        /// <param name="method">HTTP-method</param>
        /// <param name="Url">selected api path</param>
        /// <exception cref="AuthenticationException">If wrong/missing credentials for api login.</exception>
        /// <exception cref="ArgumentException">If request is of type bad request.</exception>
        /// <exception cref="KeyNotFoundException">If selected key/id does not exist.</exception>
        /// <exception cref="NotImplementedException">Remove when Method is done.</exception>
        /// <returns>JArray</returns>
        public dynamic Request(String method, string Url)
        {
            var url = _settings.BaseURI + Url;
            String result;
            try
            {
                var webRequest = WebRequest.Create(url);

                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(_auth[0] + ":" + _auth[1]));
                webRequest.Headers.Add("Authorization", "Basic " + encoded);
              
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    result = reader.ReadToEnd();
                }
                
                return JValue.Parse(result);
            }
            catch (WebException e) 
            {
                HttpWebResponse errorResponse = e.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new AuthenticationException();
                }
                else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new ArgumentException();
                }
                else if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new KeyNotFoundException();
                }       
                    throw new NotImplementedException();
                
                // TODO: add more cases of statuscodes.
            }
            catch (Exception)
            {
                throw new NotImplementedException();
                // TODO: Handle unexpected errors
            }        
        }
    }
}