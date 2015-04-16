using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Web;
using clxapi;
using System.Diagnostics;

namespace clxapi.Client
{
    public class TestClient : IHttpClient
    {
        private string [] _auth;
        private ClxSettings _settings;

        /// <summary>
        ///  Constructor to initialize ClxHtttpClient: Auth is username/password and settings is api routes of Clx api.
        /// </summary>
        /// <param name="auth">Array with username/password to api</param>
        /// <param name="settings">Dependency injection of Clx api routes</param>
        public TestClient(string [] auth, ClxSettings settings)
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
            StackTrace stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(2).GetMethod().Name;

            var testdata = new TestData();
            string data ="";
            if (methodName == "GetOperators") 
            {
                data = testdata.operators;
            }
            else if (methodName == "GetOperatorById")
            {
                data = testdata.@operator;
            }
            else if (methodName == "GetGateways")
            {
                data = testdata.gateways;
            }
            return JValue.Parse(data);          
        }
    }  
}