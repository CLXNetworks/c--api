using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    /// <summary>
    /// Example Class
    /// </summary>
    public class GetOperatorById
    {
        /// <summary>
        /// Example in how to get Operator by ID by Wrapper.
        /// </summary>
        public void Example()
        {
             try
             { 
                 var clxApi = new ClxApi(new string[] { "Username", "Password" }); 
                 var @operator = clxApi.GetOperatorById(14);
             }
             catch (ClxException e)
             {
                 string errrorMessage = e.Message;
             }
             catch (ClxApiException e)
             {
                 string clxErrrorMessage = e.ClxErrorMessage;
                 int? clxErrorCode = e.ClxErrorCode;
                 int statusCode = e.StatusCode;
             }
        }       
    }
}