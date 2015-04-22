using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Web;

namespace clxapi.Adapter
{
    /// <summary>
    /// Adapter for Htttp requests to Clx api.
    /// </summary>
    public class HttpAdapter : IHttpAdapter
    {
        /// <summary>
        /// Property with Optional Get and Set option to set Authentication.
        /// </summary>
        /// <example>Code example set Auth:
        /// <code>
        /// var adapter = new HttpAdapter();
        /// adapter.Auth = new string[] { "Username", "Password" };
        /// </code>
        /// </example>
        /// <example>Code example get Auth:
        /// <code>
        /// var adapter = new HttpAdapter();
        /// var auth = adapter.Auth;
        /// </code>
        /// </example>
        public string[] Auth { get; set; }

        /// <summary>
        /// Method used by GET Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>ClxResponse class</returns>
        public ClxResponse Get(string url) 
        {
            return Execute(url);
        }

        /// <summary>
        /// Method used by POST Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>throws new NotImplementedException</returns>
        public ClxResponse Post(string url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method used by PUT Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>throws new NotImplementedException</returns>
        public ClxResponse Put(string url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// All Requests to Clx api goes through Execute.
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>ClxResponse which contains statuscode,body,header and error of request.</returns>
        private ClxResponse Execute(string url)
        {
            ClxResponse res = new ClxResponse();
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Auth[0] + ":" + Auth[1]));
                webRequest.Headers.Add("Authorization", "Basic " + encoded);
   
                using (WebResponse response = webRequest.GetResponse())
                using (Stream content = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(content))
                {
                    string result = reader.ReadToEnd();
                    res.Body = result;
                    res.StatusCode = 200;
                    return res; 
                }               
            }
            catch (WebException e)
            {
                HttpWebResponse errorResponse = e.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    res.StatusCode = 401;
                    return res;
                }
                else if (errorResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    res.StatusCode = 400;
                    return res;
                }
                else if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    res.StatusCode = 404;
                    return res;
                }
                else
                {
                    res.StatusCode = 500; 
                    return res;
                }
            }
            catch (Exception)
            {
                res.Error = "Unexpected Exception";
                return res;
            }  
        }
    }
}