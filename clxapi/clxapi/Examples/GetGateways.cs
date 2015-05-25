using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{

    /// <summary>
    /// Exampleclass, contains example in how to get all Gateways.
    /// </summary>
    public class GetGateways
    {
        /// <summary>
        /// Remember to replace "Username" and "Password" with correct authentication.
        /// </summary>
        public void Example()
        {
            try
            {
                ClxApi clxApi = new ClxApi(new string[] { "Username", "Password" });
                IEnumerable<Gateway> gateways = clxApi.GetGateways();
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