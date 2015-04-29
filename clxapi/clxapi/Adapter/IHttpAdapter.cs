using System;
using System.Net;
namespace clxapi.Adapter
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IHttpAdapter
    {
        /// <summary>
        /// Property to set Auth.
        /// </summary>
        string[] Auth { get; set; }
        /// <summary>
        /// Method used by GET Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>ClxResponse class</returns>
        ClxResponse Get(string url);
        /// <summary>
        /// Method used by POST Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <param name="body">string representing body of post.</param>
        /// <returns>throws new NotImplementedException</returns>
        ClxResponse Post(string url, string body);
        /// <summary>
        /// Method used by PUT Requests
        /// </summary>
        /// <param name="url">string representing selected resource in api.</param>
        /// <returns>throws new NotImplementedException</returns>
        ClxResponse Put(string url);  
    }
}
