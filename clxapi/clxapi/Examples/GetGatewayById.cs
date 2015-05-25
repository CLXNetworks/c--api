using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    /// <summary>
    /// Exampleclass, contains example in how to get Gateway by id.
    /// </summary>
    public class GetGatewayById
    {
        /// <summary>
        /// Remember to replace "Username" and "Password" with correct authentication.
        /// </summary>
        public void Example() 
        {
            try
            {
                ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
                Gateway gateway = clxApi.GetGatewayById(2182);
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