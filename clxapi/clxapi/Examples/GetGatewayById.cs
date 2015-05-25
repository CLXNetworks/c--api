using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clxapi.Examples
{
    public class GetGatewayById
    {
        public void Example() 
        {
            try
            {
                var clxApi = new ClxApi(new string[] { "Username", "Password" });
                var gateway = clxApi.GetGatewayById(2182);
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