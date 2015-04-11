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
        /// <param name="method">Determine if request is of type Get, Post or Put</param>
        /// <param name="url">Api Route for selected operator</param>
        /// <returns>JArray</returns>
        dynamic Request(string method, string url);

        /// <summary>
        /// Handles Requests of type GET.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        dynamic Get(string url);

        /// <summary>
        /// Handles Requests of type POST.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        dynamic Post(string url);

        /// <summary>
        /// Handles Requests of type PUT.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        dynamic Put(string url);
    }
}
