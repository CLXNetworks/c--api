﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace clxapi
{
    public class ClxHttpClient
    {
        private string [] _auth;

        /// <summary>
        /// Constructor, take array, with username and password for api
        /// </summary>
        /// <param name="Auth"></param>
        public ClxHttpClient(string [] Auth)
        {
            _auth = Auth;
        }

        /// <summary>
        /// Property that set selected Url of chosen Operator from ClxApi.CS 
        /// </summary>
        public string Url { get; set; }

       /// <summary>
       /// Method, Handle all Requests to API with HTTP Basic Auth.
       /// </summary>
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
                throw new NotImplementedException();
                // TODO: Handle error with statuscodes
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
                // TODO: Handle unexpected errors
            }
           
        }
    }
}