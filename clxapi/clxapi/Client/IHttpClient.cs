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
        IHttpAdapter HttpAdapter { get; set; }

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

        string BaseURL { get; set; }

    }
}
