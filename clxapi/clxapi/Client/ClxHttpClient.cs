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
        public IHttpAdapter HttpAdapter{ get; set; }
        public string BaseURL{ get ; set; }

        /// <summary>
        ///  Constructor to initialize ClxHtttpClient: Auth is username/password and settings is api routes of Clx api.
        /// </summary>
        /// <param name="auth">Array with username/password to api</param>
        /// <param name="settings">Dependency injection of Clx api routes</param>
        public ClxHttpClient(string baseURL)
        {
            BaseURL = baseURL;
        }

        /// <summary>
        /// Handles Requests of type GET.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Get(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Get(fullUrl);
            return parseReponse(response);
        }

        /// <summary>
        /// Handles Requests of type POST.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Post(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Post(fullUrl);
            return parseReponse(response);
        }

        /// <summary>
        /// Handles Requests of type PUT.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        public dynamic Put(String url)
        {
            string fullUrl = BaseURL + url;
            ClxResponse response = HttpAdapter.Put(fullUrl);
            return parseReponse(response);
        }

        private dynamic parseReponse(ClxResponse response)
        {

            if (response.StatusCode > 399)
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new ClxException("Bad request");
                        break;
                    case 404:
                        
                        throw new ClxException("Fix implementation to object from api");
                        break;
                    default:
                        throw new ClxException("Unknown error");
                        break;
                }
            }
            try
            {
                return JValue.Parse(response.Body);
            }
            catch{
                throw new NotImplementedException();
            }
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
        //public dynamic Request(String method, string Url)
        //{
        //    try
        //    {
        //        var url = BaseURL + Url;
        //        WebRequest webRequest = HttpAdapter.Get(url);

        //        using (var response = webRequest.GetResponse())
        //        using (var content = response.GetResponseStream())
        //        using (var reader = new StreamReader(content))
        //        {
        //            string result = reader.ReadToEnd();
        //            return JValue.Parse(result);
        //        }
        //    }
        //    catch (WebException e) 
        //    {
        //        HttpWebResponse errorResponse = e.Response as HttpWebResponse;
        //        if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new AuthenticationException();
        //        }
        //        else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
        //        {
        //            throw new ArgumentException();
        //        }
        //        else if (errorResponse.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            throw new KeyNotFoundException();
        //        }       
        //            throw new NotImplementedException();
                
        //        // TODO: add more cases of statuscodes.
        //    }
        //    catch (Exception)
        //    {
        //        throw new NotImplementedException();
        //        // TODO: Handle unexpected errors
        //    }        
        //}






    }
}