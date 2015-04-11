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
        /// All request from ClxApi.cs goes through Request Method.
        /// </summary>
        /// <param name="url">Api Route for selected operator</param>
        /// <returns>JArray</returns>
        dynamic Request(string method, string url);

        dynamic Get(string url);

        dynamic Post(string url);
    }
}
