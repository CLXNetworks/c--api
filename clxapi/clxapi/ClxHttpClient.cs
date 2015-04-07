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
    public class ClxHttpClient
    {
        private string [] _auth;
        private Settings _settings;

        /// <summary>
        ///  Constructor to initialize ClxHtttpClient: Auth is username/password and settings is api routes of Clx api.
        /// </summary>
        /// <param name="auth">Array with username/password to api</param>
        /// <param name="settings">Dependency injection of Clx api routes</param>
        public ClxHttpClient(string [] auth, Settings settings)
        {
            _auth = auth;
            _settings = settings;
        }

        /// <summary>
        /// Property ClxApi.cs Set chosen path to this property before eatch request. ClxHttpClient then Get Url and make request.
        /// </summary>
        public string Url { get; set; }

       /// <summary>
       /// Method Handles all Http requests to Clx api.
       /// </summary>
       /// <exception cref="AuthenticationException">If wrong/missing credentials for api login.</exception>
       /// <exception cref="NotImplementedException">Remove when Method is done.</exception>
       /// <returns>JArray</returns>
        public JArray Request()
        {
            String result;
            try
            {
                var webRequest = WebRequest.Create(Url);

                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(_auth[0] + ":" + _auth[1]));
                webRequest.Headers.Add("Authorization", "Basic " + encoded);
              
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    result = reader.ReadToEnd();
                }
                
                return JArray.Parse(result);
            }
            catch (WebException e) 
            {
                HttpWebResponse errorResponse = e.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new AuthenticationException();
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