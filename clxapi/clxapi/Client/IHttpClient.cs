using clxapi.Adapter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace clxapi.Client
{
    /// <summary>
    /// Interface for ClxHttpClient.cs and TestHttpClient.cs
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Property to set BaseURL.
        /// </summary>
        string BaseURL { get; set; }

        /// <summary>
        /// Property to set what adapter to use.
        /// </summary>
        IHttpAdapter HttpAdapter { get; set; }

        /// <summary>
        /// Handles Requests of type GET.
        /// </summary>
        /// <param name="url">resourse String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        dynamic Get(string url);

        /// <summary>
        /// Handles Requests of type POST.
        /// </summary>
        /// <param name="url">resourse String</param>
        /// <param name="body">Body in form of a String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        dynamic Post(string url, string body);

        /// <summary>
        /// Handles Requests of type PUT.
        /// </summary>
        /// <param name="url">resourse String</param>
        /// <param name="body">Body in form of a String</param>
        /// <returns>Jarray or Jobject (dynamic)</returns>
        dynamic Put(string url, string body);
    }
}
